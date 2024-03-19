import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Station } from "../models/station";
import { Observable, of } from "rxjs";

@Injectable()
export class StationService
{

  private readonly host = "https://localhost:7043";

  constructor(private http: HttpClient)
  {

  }

  public getStations(): Observable<Station[]>
  {
    return this.http.get<Station[]>(this.host + "/Station/GetStations");
  }
}
