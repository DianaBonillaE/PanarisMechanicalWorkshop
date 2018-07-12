import { Component, NgModule, ViewChild } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormControl, FormGroup, ReactiveFormsModule, FormsModule } from '@angular/forms';
import { NgSelectModule, NgOption } from '@ng-select/ng-select';
import { WorkDetail } from '../model/workDetail.model';
import { WorkOrder } from '../model/workOrder.model';
import { WorkOrderService } from '../service/work-order.service';
import { WorkDetailOrderService } from '../service/work-detail-order.service';
import { Product } from '../model/product.model';
import { ProductService } from '../service/product.service';

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
  productInsert: Product = new Product();
  products:Product[]= new Array();

  pestanaSeleccionada: String = "uno";
  formularioInsertar: boolean = false;
  formularioEditar: boolean = false;
  formularioEliminar: boolean = false;


  ordenado = [
    { state: true, name: 'ordenado' },
    { state: false, name: 'No ordenado' }
  ];



  constructor(private workOrderService: WorkOrderService, private workDetailOrderService: WorkDetailOrderService, private productService: ProductService) {
    this.getAllOrders();
  }

  insertProduct() {
    this.productInsert.workDetail.idWorkDetail = this.selectedWorkDetail;
    this.productInsert.workDetail.workOrder.idWorkOrder = this.selectedWorkOrder;

    this.productService.insertProduct(this.productInsert).subscribe();

    this.reiniciarTodo();
  }

  getProducts(){
    if(this.selectedWorkDetail>0){
    this.productService.getAllProductByIdWorkDetail(this.selectedWorkDetail).subscribe(
      data=>this.products=data
    );}
  }

  reiniciarTodo() {
    this.productInsert = new Product();
    this.selectedWorkDetail = undefined;
    this.selectedWorkOrder = undefined;
    this.products=new Array();
  
  }

  getAllOrders() {
  
    this.workOrderService.getAllOrders().subscribe(data => this.workOrder = data);
  }

  getWorkDetailsByOrder() {
    this.ocultarFormularios();
    if (this.selectedWorkOrder > 0) {
      this.workDetailOrderService.getWorkDetailsByOrder(this.selectedWorkOrder).subscribe(
        data => this.workDetail = data
      );
    }

  }

  private ocultarFormularios() {
    this.formularioInsertar = false;
    this.formularioEditar = false;
    this.formularioEliminar = false;
  }





  cambiarPestana(value: String) {
    this.reiniciarTodo();
    this.pestanaSeleccionada = value;
  }


  mostrarFormularioInsertar() {
    this.formularioInsertar = true;
  }

  mostrarFormularioEditar() {

    this.formularioEditar = true;
  }

  mostrarFormularioEliminar() {

    this.formularioEliminar = true;
  }


}
