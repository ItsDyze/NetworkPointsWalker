import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { CrawledPath } from './models/crawled-path';
import { OCP } from './models/ocp';
import { OcpService } from './services/ocp.service';
import { GraphService } from './services/graph.service';
import { Constants } from '../constants';
import { BehaviorSubject, Observable, map, of, tap } from 'rxjs';
import { MapService } from './services/map.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent implements OnInit {
  public ocps: OCP[] = [];
  public ocpFrom: string = "Luxembourg";
  public ocpTo: string = "Leudelange";

  constructor(private ocpService: OcpService,
              private graphService: GraphService,
              private mapService: MapService) { }

  ngOnInit() {
    this.getOCPs();
  }

  getOCPs() {
    this.ocpService.getOCPs().subscribe(
      (result) => {
        this.ocps = result;
        this.ocpFrom = result.filter(x => x.name == "Luxembourg")[0].id;
        this.ocpTo = result.filter(x => x.name == "Leudelange")[0].id;
      }
    );
  }

  search() {
    if (this.ocpFrom && this.ocpTo) {
      this.getShortestPath(this.ocpFrom, this.ocpTo);
    }
  }

  getShortestPath(a:string, b:string) {
    this.graphService.getShortestPath(a, b)
        .subscribe((res) => {
            this.mapService.SetPaths([res]);
        })
  }

  title = 'networkpointswalker.client';
}
