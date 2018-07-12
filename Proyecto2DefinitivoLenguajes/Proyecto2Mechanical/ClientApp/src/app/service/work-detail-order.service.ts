import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';
import { WorkDetail } from '../model/workDetail.model';

@Injectable()
export class WorkDetailOrderService {

  apiUrl:String;

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.apiUrl=baseUrl;
   }

   public getWorkDetailsByOrder(id:number):Observable<WorkDetail[]>{
    return this.http.get<WorkDetail[]>(this.apiUrl+'api/workDetailOrder/'+ id);
   }

}
