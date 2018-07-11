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



  
  public insertClient(client: Client) {
    return this.http.post(this.baseUrl+'api/client', client);
  }

  public getAll() {
    return this.http.get(this.baseUrl +'api/client');
  }
}
