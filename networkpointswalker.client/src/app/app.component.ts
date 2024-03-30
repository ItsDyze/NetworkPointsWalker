import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { CrawledPath } from './models/crawled-path';
import { OCP } from './models/ocp';
import { OcpService } from './services/ocp.service';
import { GraphService } from './services/graph.service';
import { Constants } from '../constants';
import { BehaviorSubject, Observable, map, of, tap } from 'rxjs';
import { MapService } from './services/map.service';
import { environment } from '../environments/environment';

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
        this.ocpTo = result.filter(x => x.name == "Wecker")[0].id;
      }
    );
  }

  getShortest() {
    if (this.ocpFrom && this.ocpTo) {
        this.graphService.getShortestPath(this.ocpFrom, this.ocpTo)
        .subscribe((res) => {
            this.mapService.SetPaths([res]);
        })
    }
  }

  getAll(){
    if (this.ocpFrom && this.ocpTo) {
        this.graphService.getAllPaths(this.ocpFrom, this.ocpTo)
        .subscribe((res) => {
            this.mapService.SetPaths(res);
        })
    }
  }
}
