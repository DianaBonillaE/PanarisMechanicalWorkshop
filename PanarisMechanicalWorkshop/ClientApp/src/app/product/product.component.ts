import { Component, NgModule, ViewChild } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormControl, FormGroup, ReactiveFormsModule, FormsModule } from '@angular/forms';
import { NgSelectModule, NgOption } from '@ng-select/ng-select';

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.css']
})
export class ProductComponent {

  
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
  constructor() { }

  ngOnInit() {
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
