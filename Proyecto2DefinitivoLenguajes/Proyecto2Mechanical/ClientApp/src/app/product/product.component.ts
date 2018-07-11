import { Component, NgModule, ViewChild } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormControl, FormGroup, ReactiveFormsModule, FormsModule } from '@angular/forms';
import { NgSelectModule, NgOption } from '@ng-select/ng-select';
import { WorkDetail } from '../model/workDetail.model';
import { WorkOrder } from '../model/workOrder.model';
import { WorkOrderService } from '../service/work-order.service';
import { WorkDetailOrderService } from '../service/work-detail-order.service';

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.css']
})
export class ProductComponent {

  workDetail: WorkDetail[] = new Array();
  workOrder: WorkOrder[] = new Array();
  selectedWorkDetail: number;
  selectedWorkOrder: number;

  pestanaSeleccionada: String = "uno";
  formularioInsertar: boolean = false;
  formularioEditar: boolean = false;
  formularioEliminar: boolean = false;

  cities = [
    { id: 1, name: 'Vilnius' },
    { id: 2, name: 'Kaunas' },
    { id: 3, name: 'Pavilnys', disabled: true },
    { id: 4, name: 'Pabradė' },
    { id: 5, name: 'Klaipėda' }
  ];
  ordenado = [
    { id: 1, name: 'ordenado' },
    { id: 0, name: 'No ordenado' }
  ];

  selectedCity: any;

  constructor(private workOrderService: WorkOrderService, private workDetailOrderService: WorkDetailOrderService) {
    this.getAllOrders();
  }
  getAllOrders() {
    this.workOrderService.getAllOrders().subscribe(data => this.workOrder = data);
  }

  getWorkDetailsByOrder(){
    this.workDetailOrderService.getWorkDetailsByOrder(this.selectedWorkOrder).subscribe(
      data=> this.workDetail=data
    );
  }


  ngOnInit() {
  }

  imprimir(){
    console.log(this.workDetail.forEach(element => {
      element
    }));
  }

  cambiarPestana(value: String) {

    this.pestanaSeleccionada = value;
  }

  buscarDetallesTrabajo() {
    this.formularioInsertar = false;
  }

  mostrarFormularioInsertar() {

    this.formularioInsertar = true;
  }


  buscarDetallesTrabajoEditar() {
    this.formularioEditar = false;
  }

  mostrarFormularioEditar() {

    this.formularioEditar = true;
  }

  mostrarFormularioEliminar() {

    this.formularioEliminar = true;
  }

  buscarDetallesTrabajoEliminar() {
    this.formularioEliminar = false;
  }
}
