import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Station } from './models/station';
import { CrawledPath } from './models/crawled-path';







@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent implements OnInit {
  public stations: Station[] = [];
  public path: CrawledPath|null = null;

  public stationFrom: string = "Luxembourg";
  public stationTo: string = "Leudelange";
  private readonly host = "https://localhost:7043";

  constructor(private http: HttpClient) {}

  ngOnInit() {
    this.getStations();
  }

  getStations() {
    this.http.get<Station[]>(this.host+"/Graph/GetStations").subscribe(
      (result) => {
        this.stations = result;
        this.stationFrom = result.filter(x => x.name == "Luxembourg")[0].ocpId;
        this.stationTo = result.filter(x => x.name == "Leudelange")[0].ocpId;
      },
      (error) => {
        console.error(error);
      }
    );
  }

  search() {
    console.log(this.stationFrom, this.stationTo)
    if (this.stationFrom && this.stationTo) {
      this.getShortestPath(this.stationFrom, this.stationTo);
    }
  }

  getShortestPath(a:string, b:string) {
    this.http.get<CrawledPath>(this.host + "/Graph/GetShortestPath?from="+a+"&to="+b).subscribe(
      (result) => {
        this.path = result;
        console.log(result);
      },
      (error) => {
        console.error(error);
      }
    );
  }

  title = 'networkpointswalker.client';
}
