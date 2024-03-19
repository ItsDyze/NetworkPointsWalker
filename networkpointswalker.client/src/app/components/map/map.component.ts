import { Component, Input } from '@angular/core';
import { OCP } from '../../models/ocp';
import { CrawledPath } from '../../models/crawled-path';
import { StationService } from '../../services/station.service';
import { Station } from '../../models/station';

@Component({
  selector: 'app-map',
  templateUrl: './map.component.html',
  styleUrl: './map.component.css'
})
export class MapComponent {
  @Input() crawledPath: CrawledPath | null = null;
  public stations: Station[] = [];

  private _height = 2000;
  private _width = 2000;
  private margin = 100;
  private pointSize = 4;

  public height: number = this._height + this.margin;
  public width: number = this._width + this.margin;
  
  private textHeightSpacing = -10;

  constructor(private stationService: StationService)
  {
    stationService.getStations().subscribe(x => {
      let lats = x.map(s => s.ocp.coordinates.latitude);
      let longs = x.map(s => s.ocp.coordinates.longitude);

      let maxLat = Math.max(...lats);
      let minLat = Math.min(...lats);

      let maxLong = Math.max(...longs);
      let minLong = Math.min(...longs);
      
      this.stations = x.map(s => {
        s.normalizedCoords = {
          latitude: (s.ocp.coordinates.latitude - minLat) / (maxLat - minLat),
          longitude: (s.ocp.coordinates.longitude - minLong) / (maxLong - minLong)
        }
        return s;
      });
        
      this.buildMap();

    });
  }

  public buildMap()
  {
    let canvas = document.getElementById('map') as
      HTMLCanvasElement;
    let context = canvas.getContext("2d");
    if (context != null) {
      context.clearRect(0, 0, this.width, this.height);
      context.fillStyle = "white";

      this.stations.forEach(s => {
        context?.fillRect(this.getRealValueFromNormalizedValue(s.normalizedCoords.longitude, this._width),
          this.getRealValueFromNormalizedValue(s.normalizedCoords.latitude, this._height, true),
          this.pointSize,
          this.pointSize);

        context?.fillText(s.name,
          this.getRealValueFromNormalizedValue(s.normalizedCoords.longitude, this._width),
          this.getRealValueFromNormalizedValue(s.normalizedCoords.latitude, this._height, true));
      });

      if (this.crawledPath) {
        let previousStation: Station | null = null;
        this.crawledPath.ocPs.forEach(o => {
          let currentStation = this.stations.filter(s => s.ocpId == o.id)[0];
          if (previousStation && context) {
            context.strokeStyle = "red";
            context.lineWidth = 3;
            context.beginPath();
            context.moveTo(this.getRealValueFromNormalizedValue(currentStation.normalizedCoords.longitude, this._width),
              this.getRealValueFromNormalizedValue(currentStation.normalizedCoords.latitude, this._height, true));
            context.lineTo(this.getRealValueFromNormalizedValue(previousStation.normalizedCoords.longitude, this._width),
              this.getRealValueFromNormalizedValue(previousStation.normalizedCoords.latitude, this._height, true));
            context.stroke();
          }
          previousStation = currentStation;

        })
      }

    }
  }

  private getRealValueFromNormalizedValue(v: number, maxValue: number, revert:boolean = false): number
  {
    if (revert) {
      return maxValue - (Math.abs(v) * maxValue) + (this.margin / 2);
    }
    else {
      return (Math.abs(v) * maxValue) + (this.margin / 2);
    }
    
  }
}
