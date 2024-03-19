import { Coordinates } from "./coordinates";
import { OCP } from "./ocp";

export interface Station {
  id: string;
  name: string;
  ocpId: string;
  ocp: OCP;
  normalizedCoords: Coordinates;
}
