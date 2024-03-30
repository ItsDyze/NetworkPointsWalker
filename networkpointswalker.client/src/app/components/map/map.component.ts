import { AfterViewInit, Component, Input, OnChanges, SimpleChanges } from '@angular/core';
import { OCP } from '../../models/ocp';
import { CrawledPath } from '../../models/crawled-path';
import { OcpService } from '../../services/ocp.service';
import { Constants } from '../../../constants';
import { Observable, of, tap, timeout } from 'rxjs';
import { MapService } from '../../services/map.service';
import { MapLocation } from '../../models/map-location';
import { Segment } from '../../models/segment';
import { MapPath } from '../../models/map-path';

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
    private paths: MapPath[] = [];
    private context: CanvasRenderingContext2D | null = null;
    private _canvas: HTMLCanvasElement|any;
    private service: MapService;
    private mouseDrag: boolean = false;
    private mouseDragStartPos: any;
    private currentTransformedCursor: any;
    private drawingIndex: number = 0;

    public showAllNames: boolean = false;
    public showAllPaths: boolean = true;

    get pathsCount() {
        return this.paths.length;
    }
    get currentPathId() {
        return this.drawingIndex + 1;
    }
    
    constructor(private ocpService: OcpService,
                private mapService: MapService)
    {
        this.service = mapService;
        
    }
    ngAfterViewInit() {
        let canvas = document.getElementById('map') as HTMLCanvasElement;
        this._canvas = canvas;
        canvas.addEventListener('mousedown', (e) => {this.mouseDrag = true; this.mouseDragStartPos = this.getTransformedPoint(e.offsetX, e.offsetY);})
        canvas.addEventListener('mouseup', (e) => {this.mouseDrag = false; })
        canvas.addEventListener('mousemove', (e) => {            
            if (this.mouseDrag) {
                this.currentTransformedCursor = this.getTransformedPoint(e.offsetX, e.offsetY);
                this.context?.translate(this.currentTransformedCursor.x - this.mouseDragStartPos.x, this.currentTransformedCursor.y - this.mouseDragStartPos.y);
                this.Draw();
            }
        });
        canvas.addEventListener("wheel", (e) => {
            if(this.currentTransformedCursor)
            {
                const zoom = e.deltaY < 0 ? 1.1 : 0.9;
    
                this.context?.translate(this.currentTransformedCursor.x, this.currentTransformedCursor.y);
                this.context?.scale(zoom, zoom);
                this.context?.translate(-this.currentTransformedCursor.x, -this.currentTransformedCursor.y);
                    
                this.Draw();
                e.preventDefault();
            }
            
        })

        if (canvas) {
            this.context = canvas.getContext("2d");
        }
        else {
            console.error("Couldn't load the canvas context");
        }
        this.height = canvas.height;
        this.width = canvas.width;

        this.mapService.Locations$.subscribe((l) => {
            if(l){
                this.locations.push(l);
                this.Draw();
            }
        });

        this.mapService.Paths$.subscribe((p) => {
            if(p)
            {
                this.paths = p;
                this.Draw();
            }
        });
    }
    
    public Draw(cyclePath: boolean = false) {
        this.drawingIndex = cyclePath && this.paths.length - 1 > this.drawingIndex ? this.drawingIndex + 1 : 0;
        this.Clear();
        let namesToShow: string[] = [];
        let pathsToDraw: MapPath[] = this.showAllPaths ?  this.paths : [this.paths[this.drawingIndex]];
        pathsToDraw.forEach(p => {
            if(p)
            {
                if(!this.showAllNames)
                {
                    namesToShow = this.getTargetedLocationNames(p);
                }
        
                p.segments.forEach(s => s.Draw(this.context!));
            }
        })

        this.locations.forEach(l => l.Draw(this.context!, namesToShow));
    }
    
    private Clear() {
        // Store the current transformation matrix
        this.context?.save();

        // Use the identity matrix while clearing the canvas
        this.context?.setTransform(1, 0, 0, 1, 0, 0);
        this.context?.clearRect(0, 0, this._canvas.width, this._canvas.height);

        // Restore the transform
        this.context?.restore();
    }

    private getTransformedPoint(x:number, y:number) {
        const originalPoint = new DOMPoint(x, y);
        return this.context?.getTransform().invertSelf().transformPoint(originalPoint);
    }

    private getTargetedLocationNames(path: MapPath): string[] {
        let result: string[] = [];
        path.locations.forEach(l => {
                result.push(l.name);
        });
        return result;
    }
}

