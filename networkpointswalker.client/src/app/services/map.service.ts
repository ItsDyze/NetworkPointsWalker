import { Injectable, OnInit } from "@angular/core";
import { Segment } from "../models/segment";
import { Constants } from "../../constants";
import { MapLocation } from "../models/map-location";
import { CrawledPath } from "../models/crawled-path";
import { OcpService } from "./ocp.service";
import { OCP } from "../models/ocp";
import { BehaviorSubject, Observable } from "rxjs";
import { MapPath } from "../models/map-path";

@Injectable({
    providedIn: 'root',
  })
export class MapService
{

    public OCPs: OCP[] = [];
    private _locationsSubject: BehaviorSubject<MapLocation|null> = new BehaviorSubject<MapLocation|null>(null);
    public Locations$: Observable<MapLocation|null> = this._locationsSubject.asObservable();
    private _segmentSubject: BehaviorSubject<Segment|null> = new BehaviorSubject<Segment|null>(null);
    public Segments$: Observable<Segment|null> = this._segmentSubject.asObservable();
    private _pathSubject: BehaviorSubject<MapPath[]|null> = new BehaviorSubject<MapPath[]|null>(null);
    public Paths$: Observable<MapPath[]|null> = this._pathSubject.asObservable();
    private OCPService: OcpService;    
    
    constructor(private ocpService: OcpService) {
        this.OCPService = ocpService;
        this.OCPService.getOCPs().subscribe(ocps => {
            this.OCPs = this.prepareOCPs(ocps);
            ocps.forEach(o => {
                let location = new MapLocation(o.name, o.preparedCoords);
                this._locationsSubject.next(location);
            });
        });
    }

    public SetPaths(paths: CrawledPath[])
    {
        let newPaths:MapPath[] = paths.map<MapPath>((p, i) => {
            let segments = this.prepareSegments(p);
            let locations:any = [];
            segments.forEach(s => {
                locations.push(s.locationA, s.locationB)
            })
            locations = [...new Set(locations)];

            return {
                id: i,
                segments: segments,
                locations: locations
            };
        });
        this._pathSubject.next(newPaths);
    }

    private prepareOCPs(x: OCP[]): OCP[] {
        let lats = x.map(o => o.coordinates.latitude);
        let longs = x.map(o => o.coordinates.longitude);
        
        let maxLat = Math.max(...lats);
        let minLat = Math.min(...lats);
        
        let maxLong = Math.max(...longs);
        let minLong = Math.min(...longs);
        
        return x.map(o => {
            o.preparedCoords = {
                latitude: this.getRealValueFromNormalizedValue((o.coordinates.latitude - minLat) / (maxLat - minLat), Constants.MAP.HEIGHT, true),
                longitude: this.getRealValueFromNormalizedValue((o.coordinates.longitude - minLong) / (maxLong - minLong), Constants.MAP.WIDTH)
            };
            return o;
        });
    }

    private prepareSegments(x: CrawledPath): Segment[]{
        let result: Segment[] = [];

        let previousOCP:OCP|null = null;
        x.ocPs.forEach(o => {
            let currentOCP = this.OCPs.filter(x => x.id == o.id)[0];
            if(previousOCP != null)
            {
                result.push(new Segment(new MapLocation(previousOCP.name, previousOCP.preparedCoords), 
                new MapLocation(currentOCP.name, currentOCP.preparedCoords)));
            }

            previousOCP = currentOCP;
        })

        return result;
    }
    
    private getRealValueFromNormalizedValue(v: number, maxValue: number, revert:boolean = false): number
    {
        if (revert) {
            return maxValue - (Math.abs(v) * maxValue);
        }
        else {
            return (Math.abs(v) * maxValue);
        }
        
    }

    
    
}
