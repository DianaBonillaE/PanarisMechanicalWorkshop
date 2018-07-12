import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { WorkOrder } from '../model/workOrder.model';
import { Observable } from 'rxjs/Observable';

@Injectable()
export class WorkOrderService {

  apiUrl:String;

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.apiUrl=baseUrl;
   }

   public getAllOrders():Observable<WorkOrder[]>{
    return this.http.get<WorkOrder[]>(this.apiUrl+'api/workOrder');
   }

}

