import { Component, OnInit } from '@angular/core';
import { Client } from '../model/client.model';

import { Router } from '@angular/router';
import { ClientService } from '../service/client.service';
import { Vehicle } from '../model/vehicle.model';

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
    this.service.insert(this.client).subscribe(
      (data: Client) => {
        this.client = data;
      }
    )
    this.form = false;
    this.formInsert = true;
  }
  vehicleInsert() {
    this.service.insertV(this.vehicle).subscribe(
      (data: Vehicle) => {
        this.vehicle = data;
      }
    )
  }
}
