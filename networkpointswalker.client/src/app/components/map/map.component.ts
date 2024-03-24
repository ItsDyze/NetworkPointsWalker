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
    private isUpdated: boolean = true;
    private mouseDrag: boolean = false;
    private mouseDragStartPos: any;
    private currentTransformedCursor: any;
    
    constructor(private ocpService: OcpService,
                private mapService: MapService)
    {
        this.service = mapService;
        
    }
    
    ngAfterViewInit() {
        let canvas = document.getElementById('map') as HTMLCanvasElement;
        canvas.addEventListener('mousedown', (e) => {this.mouseDrag = true;})
        canvas.addEventListener('mouseup', (e) => {this.mouseDrag = false; this.mouseDragStartPos = this.getTransformedPoint(e.offsetX, e.offsetY);})
        canvas.addEventListener('mousemove', (e) => {            
            if (this.mouseDrag) {
                this.currentTransformedCursor = this.getTransformedPoint(e.offsetX, e.offsetY);
                this.currentTransformedCursor = this.getTransformedPoint(e.offsetX, e.offsetY);
                this.context?.translate(this.currentTransformedCursor.x - this.mouseDragStartPos.x, this.currentTransformedCursor.y - this.mouseDragStartPos.y);
                this.Draw();
            }
        });
        canvas.addEventListener("wheel", (e) => {
            const zoom = e.deltaY < 0 ? 1.1 : 0.9;
    
            this.context?.translate(this.currentTransformedCursor.x, this.currentTransformedCursor.y);
            this.context?.scale(zoom, zoom);
            this.context?.translate(-this.currentTransformedCursor.x, -this.currentTransformedCursor.y);
                
            this.Draw();
            e.preventDefault();
        })

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
        this.segments = [];
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
    
    public StartDrawing() {
        if(!this.context){
            throw new Error("Context not set");
        }

        setTimeout(() => {
            if(this.isUpdated)
            {
                this.Clear();
                this.Draw();
                this.isUpdated = false;
            }
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

    private getTransformedPoint(x:number, y:number) {
        const originalPoint = new DOMPoint(x, y);
        return this.context?.getTransform().invertSelf().transformPoint(originalPoint);
    }
}
