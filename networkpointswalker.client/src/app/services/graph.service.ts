import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable, of } from "rxjs";
import { OCP } from "../models/ocp";
import { CrawledPath } from "../models/crawled-path";
import { environment } from "../../environments/environment";

@Injectable()
export class GraphService
{

    api: string = environment.api;
  constructor(private http: HttpClient)
  {

  }

  public getShortestPath(a: string, b: string): Observable<CrawledPath>
  {
    return this.http.get<CrawledPath>(this.api + "Graph/GetShortestPath?from=" + a + "&to=" + b);
  }

  public getAllPaths(a: string, b: string): Observable<CrawledPath[]>
  {
    return this.http.get<CrawledPath[]>(this.api + "Graph/GetAllPaths?from=" + a + "&to=" + b);
  }
}
