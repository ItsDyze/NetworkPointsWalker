import { Coordinates } from "./coordinates";

export interface OCP {
  id: string;
  name: string;
  coordinates: Coordinates;
  preparedCoords: Coordinates;
}
