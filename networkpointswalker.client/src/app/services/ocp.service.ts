import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable, of } from "rxjs";
import { OCP } from "../models/ocp";

@Injectable()
export class OcpService
{
  constructor(private http: HttpClient)
  {

  }

  public getOCPs(): Observable<OCP[]>
  {
    return this.http.get<OCP[]>("api/OCP");
  }
}
