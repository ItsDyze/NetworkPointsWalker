import { MapLocation } from "./map-location";

export class Segment {
    public locationA: MapLocation;
    public locationB: MapLocation;
    
    constructor(locA:MapLocation, locB:MapLocation){
        this.locationA = locA;
        this.locationB = locB;
    }
    
    public Draw = (ctx: CanvasRenderingContext2D) => {
        ctx.strokeStyle = "green";
        ctx.lineWidth = 3;
        ctx.beginPath();
        ctx.moveTo(this.locationA.canvasCoordinates.longitude, this.locationA.canvasCoordinates.latitude);
        ctx.lineTo(this.locationB.canvasCoordinates.longitude, this.locationB.canvasCoordinates.latitude);
        ctx.stroke();
    }
}
    