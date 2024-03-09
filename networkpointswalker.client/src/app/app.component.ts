import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

interface Station {
  id: string;
  name: string;
  ocpId: string;
}

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent implements OnInit {
  public stations: Station[] = [];
  public path: string[] = [];

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
    this.http.get<string[]>(this.host + "/Graph/GetShortestPath?from="+a+"&to="+b).subscribe(
      (result) => {
        this.path = result;
      },
      (error) => {
        console.error(error);
      }
    );
  }

  title = 'networkpointswalker.client';
}
