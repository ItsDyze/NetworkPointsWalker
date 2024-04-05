import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable, of } from "rxjs";
import { OCP } from "../models/ocp";
import { environment } from "../../environments/environment";

@Injectable()
export class OcpService
{
    
    api: string = environment.api;

  constructor(private http: HttpClient)
  {

  }

  public getOCPs(): Observable<OCP[]>
  {
    return this.http.get<OCP[]>(this.api + "OCP");
  }
}
