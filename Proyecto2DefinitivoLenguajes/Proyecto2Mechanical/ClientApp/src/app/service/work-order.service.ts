import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { WorkOrder } from '../model/workOrder.model';
import { Observable } from 'rxjs/Observable';
import { WorkDetail } from '../model/workDetail.model';
import { VehicleDetail } from '../model/vehicleDetail.model';
import { TypeDetail } from '../model/typeDetail.model';
import { Condition } from '../model/condition.model';

@Injectable()
export class WorkOrderService {

  apiUrl:String;

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.apiUrl=baseUrl;
   }

   public getAllOrders():Observable<WorkOrder[]>{
    return this.http.get<WorkOrder[]>(this.apiUrl+'api/workOrder');
  }

  public insertWorkOrder(workOrder:WorkOrder)
  {
    return this.http.post(this.apiUrl + 'api/workOrder', workOrder);
  }

  public insertWorkDetail(workDetail: WorkDetail) {
    return this.http.post(this.apiUrl + 'api/workDetailOrder', workDetail);
  }

  public insertVehicleDetail(vehicleDetail: VehicleDetail) {
    console.log(vehicleDetail.observations);
    console.log(vehicleDetail.quantity);
    return this.http.post(this.apiUrl + 'api/prueba', vehicleDetail);
  }

  public getAllClients() {
    return this.http.get(this.apiUrl + 'api/client');
  }

  public getAllVehicles() {
    return this.http.get(this.apiUrl + 'api/vehicle');
  }

  public getAlltypes() {
    return this.http.get(this.apiUrl + 'api/typeDetail');
  }

  public getAllConditions() {
    return this.http.get(this.apiUrl + 'api/condition');
  }

}

