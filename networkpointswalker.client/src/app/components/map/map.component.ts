import { AfterViewInit, Component, Input, OnChanges, SimpleChanges } from '@angular/core';
import { OCP } from '../../models/ocp';
import { CrawledPath } from '../../models/crawled-path';
import { OcpService } from '../../services/ocp.service';
import { Constants } from '../../../constants';
import { Observable, of, tap } from 'rxjs';
import { MapService } from '../../services/map.service';
import { MapLocation } from '../../models/map-location';
import { Segment } from '../../models/segment';

@Component({
    selector: 'app-map',
    templateUrl: './map.component.html',
    styleUrl: './map.component.css'
})
export class MapComponent implements AfterViewInit {
    
    public Constants = Constants;
    
    private margin: number = Constants.MAP.MARGIN;
    private pointSize: number = Constants.MAP.POINT_SIZE;
    private textHeightSpacing: number = Constants.MAP.TEXT_HEIGHT_SPACING;
    private height: number = 0;
    private width: number = 0;
    private locations: MapLocation[] = [];
    private segments: Segment[] = [];
    private context: CanvasRenderingContext2D | null = null;
    private service: MapService;
    
    constructor(private ocpService: OcpService,
                private mapService: MapService)
    {
        this.service = mapService;
        
    }
    
    ngAfterViewInit() {
        let canvas = document.getElementById('map') as HTMLCanvasElement;
        if (canvas) {
            this.context = canvas.getContext("2d");
        }
        else {
            console.error("Couldn't load the canvas context");
        }
        this.height = canvas.height;
        this.width = canvas.width;
        this.StartDrawing();

        this.service.Locations$.subscribe((res) => {
            if(res)
            {
                this.AddLocation(res);
            }
        });
        this.service.Segments$.subscribe((res) => {
            if(res)
            {
                this.AddSegment(res);
            }
        });
    }
    
    public SetContext(canvas: HTMLCanvasElement){
        let retrievedCanvas = canvas.getContext("2d");
        
    }
    
    public AddLocation(x: MapLocation) {
        this.locations.push(x);
        this.Draw();
    }

    public AddSegment(x: Segment) {
        this.segments.push(x);
        this.Draw();
    }
    
    public AddPath(path: CrawledPath)
    {
        let previousLocation: MapLocation|null = null;
        path.ocPs.forEach(o => {
            if(!previousLocation){
                previousLocation = new MapLocation(o.name, o.preparedCoords);
            }
            else
            {
                let nextLocation = new MapLocation(o.name, o.preparedCoords);
                this.AddSegment(new Segment(previousLocation, nextLocation));
                previousLocation = nextLocation;
            }
        });
    }

    public ClearData() {
        this.locations = [];
        this.segments = [];
    }
    
    public StartDrawing() {
        if(!this.context){
            throw new Error("Context not set");
        }

        setTimeout(() => {
            this.Draw();
        }, 1000);
    }
    
    private Draw() {
        this.Clear();
        this.locations.forEach(l => l.Draw(this.context!));
        this.segments.forEach(s => s.Draw(this.context!));
    }
    
    private Clear() {
        this.context?.clearRect(0, 0, this.width, this.height);
    }
}
