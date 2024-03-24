import { Constants } from "../../constants";
import { Coordinates } from "./coordinates";

export class MapLocation {
    public name: string;
    public canvasCoordinates: Coordinates;
    
    constructor(pName: string, pCoordinates: Coordinates) {
        this.name = pName;
        this.canvasCoordinates = pCoordinates;
    }
    
    public Draw = (ctx: CanvasRenderingContext2D, hideLocationNames = false) => {
        ctx.strokeStyle = "white";
        ctx.fillStyle = "white";
        ctx?.fillRect(this.canvasCoordinates.longitude,
            this.canvasCoordinates.latitude,
            Constants.MAP.POINT_SIZE,
            Constants.MAP.POINT_SIZE);
            
            if (!hideLocationNames) {
                ctx?.fillText(this.name,
                    this.canvasCoordinates.longitude,
                    this.canvasCoordinates.latitude);
            };
    }
}
    
