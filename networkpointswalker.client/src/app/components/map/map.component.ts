import { Component, Input } from '@angular/core';
import { OCP } from '../../models/ocp';
import { CrawledPath } from '../../models/crawled-path';
import { OcpService } from '../../services/ocp.service';

@Component({
  selector: 'app-map',
  templateUrl: './map.component.html',
  styleUrl: './map.component.css'
})
export class MapComponent {
  @Input() crawledPath: CrawledPath[] | null = null;
  public ocps: OCP[] = [];

  private _height = 2000;
  private _width = 2000;
  private margin = 100;
  private pointSize = 4;

  public height: number = this._height + this.margin;
  public width: number = this._width + this.margin;
  
  private textHeightSpacing = -10;

  constructor(private ocpService: OcpService)
  {
    ocpService.getOCPs().subscribe(x => {
      let lats = x.map(o => o.coordinates.latitude);
      let longs = x.map(o => o.coordinates.longitude);

      let maxLat = Math.max(...lats);
      let minLat = Math.min(...lats);

      let maxLong = Math.max(...longs);
      let minLong = Math.min(...longs);
      
      this.ocps = x.map(o => {
        o.normalizedCoords = {
          latitude: (o.coordinates.latitude - minLat) / (maxLat - minLat),
          longitude: (o.coordinates.longitude - minLong) / (maxLong - minLong)
        }
        return o;
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

      this.ocps.forEach(o => {
        context?.fillRect(this.getRealValueFromNormalizedValue(o.normalizedCoords.longitude, this._width),
          this.getRealValueFromNormalizedValue(o.normalizedCoords.latitude, this._height, true),
          this.pointSize,
          this.pointSize);

        context?.fillText(o.name,
          this.getRealValueFromNormalizedValue(o.normalizedCoords.longitude, this._width),
          this.getRealValueFromNormalizedValue(o.normalizedCoords.latitude, this._height, true));
      });

      if (this.crawledPath) {
        let previousOCP: OCP | null = null;
        this.crawledPath[0].ocPs.forEach(o => {
          let currentOCP = this.ocps.filter(ocp => ocp.id == o.id)[0];

          if (o && previousOCP && context) {
            context.strokeStyle = "red";
            context.lineWidth = 3;
            context.beginPath();
            context.moveTo(this.getRealValueFromNormalizedValue(currentOCP.normalizedCoords.longitude, this._width),
              this.getRealValueFromNormalizedValue(currentOCP.normalizedCoords.latitude, this._height, true));
            context.lineTo(this.getRealValueFromNormalizedValue(previousOCP.normalizedCoords.longitude, this._width),
              this.getRealValueFromNormalizedValue(previousOCP.normalizedCoords.latitude, this._height, true));
            context.stroke();

          }

          previousOCP = currentOCP ? currentOCP : previousOCP;

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
