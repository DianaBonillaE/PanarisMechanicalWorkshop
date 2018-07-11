import { Injectable, Inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';
import { Client } from '../model/client.model';


@Injectable()
export class ClientService {
  httpOptions = {
    headers : new HttpHeaders({'Content-Type': 'application/json'})
};
  baseUrl: String;
  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.baseUrl = baseUrl;
  }



  
  public insert(id: string, name: string, lastName: string, phone: string, address: string, email: string) {
    return this.http.get(this.baseUrl + 'api/client/' + id + '/' + name + '/' + lastName + '/' + phone + '/' + address + '/'+ email);
  }

  public getAll() {
    return this.http.get(this.baseUrl +'api/client');
  }
  public insertV(vehicleId: string, color: string, brand: string, style: string, year: string, power: string, displacement: string, capacity: string, weight: string, chasisNumber: string, motorNumber: string) {
    return this.http.get(this.baseUrl + 'api/vehicle');
  }
}
