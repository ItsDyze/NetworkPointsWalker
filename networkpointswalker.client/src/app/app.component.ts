import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { CrawledPath } from './models/crawled-path';
import { OCP } from './models/ocp';
import { OcpService } from './services/ocp.service';
import { GraphService } from './services/graph.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent implements OnInit {
  public ocps: OCP[] = [];
  public path: CrawledPath|null = null;

  public ocpFrom: string = "Luxembourg";
  public ocpTo: string = "Leudelange";

  constructor(private ocpService: OcpService,
              private graphService: GraphService) { }

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
    this.graphService.getShortestPath(a, b).subscribe(
      (result) => {
        this.path = result;
      }
    );
  }

  title = 'networkpointswalker.client';
}
