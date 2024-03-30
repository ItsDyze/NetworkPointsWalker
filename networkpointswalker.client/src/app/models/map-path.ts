import { MapLocation } from "./map-location";
import { Segment } from "./segment";

export interface MapPath {
    id: number;
    segments: Segment[];
    locations: MapLocation[];
}