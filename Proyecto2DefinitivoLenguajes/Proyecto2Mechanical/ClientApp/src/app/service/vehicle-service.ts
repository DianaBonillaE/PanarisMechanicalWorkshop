import { Injectable, Inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';
import { Vehicle } from '../model/vehicle.model';

@Injectable()
export class VehicleService {
  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  };
  baseUrl: String;
  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.baseUrl = baseUrl;
  }
  public insertV(vehicle: Vehicle) {
    return this.http.post(this.baseUrl + 'api/vehicle', vehicle);
  }
}
