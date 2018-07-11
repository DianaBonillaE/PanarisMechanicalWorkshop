import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';
import { Vehicle } from '../model/vehicle.model';

@Injectable()
export class VehicleService {

  httpOptions = {
    headers : new HttpHeaders({'Content-Type': 'application/json'})
};
  constructor(private http: HttpClient) {}

  private requestMapping = 'vehicle/';
 private apiUrl:"http://localhost:44370/api/";

  private url = this.apiUrl + this.requestMapping;

  
  public insertVehicle(vehicle: Vehicle){
    return this.http.post(this.url,vehicle);
  }
}