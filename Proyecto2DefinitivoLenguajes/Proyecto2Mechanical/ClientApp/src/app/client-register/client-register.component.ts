import { Component, OnInit } from '@angular/core';
import { Client } from '../model/client.model';

import { Router } from '@angular/router';
import { ClientService } from '../service/client.service';
import { Vehicle } from '../model/vehicle.model';
import { VehicleService } from '../service/vehicle.service';

@Component({
  selector: 'app-client-register',
  templateUrl: './client-register.component.html',
  styleUrls: ['./client-register.component.css']
})
export class ClientRegisterComponent implements OnInit {
  formInsert: boolean;
  form:boolean;
  client: Client = new Client();
  vehicle: Vehicle = new Vehicle();
  clients: Client[] = new Array<Client>();
  constructor(private router: Router, private service: ClientService) { }
  
    ngOnInit() {
      this.form=true;
    }
  
    showVehicleform() {
      this.form = false;
      this.formInsert = true;
  }
  insert() {
    this.service.insert(this.client.idClient, this.client.clientName, this.client.lastName, this.client.phoneNumber, this.client.address, this.client.email).subscribe(
        (data: Client) => {
          this.client = data;
        }
      )
  }
  vehicleInsert() {
    this.service.insertV(this.vehicle.vehicleId, this.vehicle.color, this.vehicle.brand, this.vehicle.style, this.vehicle.year, this.vehicle.power, this.vehicle.displacement, this.vehicle.capacity, this.vehicle.weight, this.vehicle.chasisNumber, this.vehicle.motorNumber).subscribe(
      (data: Vehicle) => {
        this.vehicle = data;
      }
    )
  }
}
