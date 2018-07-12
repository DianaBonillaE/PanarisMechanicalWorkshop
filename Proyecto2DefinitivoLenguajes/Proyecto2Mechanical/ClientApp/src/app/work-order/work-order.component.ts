import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { WorkOrder } from '../model/workOrder.model';
import { WorkOrderService } from '../service/work-order.service';
import { Client } from '../model/client.model';
import { ClientService } from '../service/client.service';
import { Vehicle } from '../model/vehicle.model';
import { VehicleRegisterService } from '../service/vehicle-register.service';
import { WorkDetail } from '../model/workDetail.model';
import { VehicleDetail } from '../model/vehicleDetail.model';
import { TypeDetail } from '../model/typeDetail.model';
import { Condition } from '../model/condition.model';

@Component({
  selector: 'app-work-order',
  templateUrl: './work-order.component.html',
  styleUrls: ['./work-order.component.css']
})
export class WorkOrderComponent implements OnInit {

  pestanaSeleccionada: String = "uno";
  
  clients: Client[] = new Array<Client>();
  client: Client = new Client();

  vehicles: Vehicle[] = new Array<Vehicle>();
  vehicle: Vehicle = new Vehicle();

  workOrders: WorkOrder[] = new Array<WorkOrder>();
  workOrder: WorkOrder = new WorkOrder();

  workDetail: WorkDetail = new WorkDetail();

  vehicleDetail: VehicleDetail = new VehicleDetail();

  types: TypeDetail[] = new Array<TypeDetail>();
  typeDetail: TypeDetail = new TypeDetail();

  conditions: Condition[] = new Array<Condition>();
  condition: Condition = new Condition();

  constructor(private router: Router, private service: WorkOrderService) { }

  ngOnInit() {
    console.log(this.vehicleDetail);
    this.service.getAllClients().subscribe((data: Client[]) => {
      this.clients = data;
    })

    this.service.getAllVehicles().subscribe((data: Vehicle[]) => {
      this.vehicles = data;
    })

    this.service.getAllOrders().subscribe((data: WorkOrder[]) => {
      this.workOrders = data;
    })

    this.service.getAlltypes().subscribe((data: TypeDetail[]) => {
      this.types = data;
    })

    this.service.getAllConditions().subscribe((data: Condition[]) => {
      this.conditions = data;
    })
  }

  cambiarPestana(value: String) {

    this.pestanaSeleccionada = value;
  }

  insertWO() {
    this.service.insertWorkOrder(this.workOrder).subscribe(
      (data: WorkOrder) => {
        this.workOrder = data;
      }
    )
  }

  insertDT() {
    this.service.insertWorkDetail(this.workDetail).subscribe(
      (data: WorkDetail) => {
        this.workDetail = data;
      }
    )
  }

  insertDV() {
    console.log(this.vehicleDetail.quantity);
    this.service.insertVehicleDetail(this.vehicleDetail).subscribe();
  }

}
