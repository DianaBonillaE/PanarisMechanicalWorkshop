import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-work-order',
  templateUrl: './work-order.component.html',
  styleUrls: ['./work-order.component.css']
})
export class WorkOrderComponent implements OnInit {

  pestanaSeleccionada: String = "uno";

  constructor() { }

  ngOnInit() {
  }

  cambiarPestana(value: String) {

    this.pestanaSeleccionada = value;
  }

}
