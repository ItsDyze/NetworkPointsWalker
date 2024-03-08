import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

interface Station {
  id: string;
  name: string;
}

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent implements OnInit {
  public stations: Station[] = [];
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

  title = 'networkpointswalker.client';
}
