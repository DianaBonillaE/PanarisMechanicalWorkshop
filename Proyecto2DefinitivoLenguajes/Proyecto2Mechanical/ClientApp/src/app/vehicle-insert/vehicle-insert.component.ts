import { Component, OnInit } from '@angular/core';
import { Vehicle } from '../model/vehicle.model';
import { Router } from '@angular/router';
import { VehicleRegisterService } from '../service/vehicle-register.service';

@Component({
  selector: 'app-vehicle-insert',
  templateUrl: './vehicle-insert.component.html',
  styleUrls: ['./vehicle-insert.component.css']
})
export class VehicleInsertComponent implements OnInit {

  vehicle: Vehicle = new Vehicle();
  constructor(private router: Router, private service: VehicleRegisterService) { }

  ngOnInit() {
  }
  vehicleInsert() {
    this.service.insertV(this.vehicle).subscribe(
      (data: Vehicle) => {
        this.vehicle = data;
      }
    )
  }
}
