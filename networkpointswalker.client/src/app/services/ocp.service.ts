import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable, of } from "rxjs";
import { OCP } from "../models/ocp";

@Injectable()
export class OcpService
{

  private readonly host = "https://localhost:7043";

  constructor(private http: HttpClient)
  {

  }

  public getOCPs(): Observable<OCP[]>
  {
    return this.http.get<OCP[]>(this.host + "/OCP");
  }
}
