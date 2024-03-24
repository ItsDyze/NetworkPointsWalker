import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable, of } from "rxjs";
import { OCP } from "../models/ocp";
import { CrawledPath } from "../models/crawled-path";

@Injectable()
export class GraphService
{

  private readonly host = "https://localhost:7043";

  constructor(private http: HttpClient)
  {

  }

  public getShortestPath(a: string, b: string): Observable<CrawledPath>
  {
    return this.http.get<CrawledPath>(this.host + "/Graph/GetShortestPath?from=" + a + "&to=" + b);
  }
}
