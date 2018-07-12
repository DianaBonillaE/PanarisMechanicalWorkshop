import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'app-client',
  templateUrl: './client.component.html',
  styleUrls: ['./client.component.css']
})
export class ClientComponent implements OnInit {
  pestanaSeleccionada: String;
  constructor() { }

  ngOnInit() {
    this.pestanaSeleccionada = "uno";
  }

  cambiarPestana(value: String) {
    this.pestanaSeleccionada = value;
  }

  // For @Output
  dataFromChild: string;
  fetchDataFromChild(data: string) {
    this.pestanaSeleccionada=data;
    this.dataFromChild = data;
  }

  mostrar() {
    
    alert(this.dataFromChild);
  }
}
