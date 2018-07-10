import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-client',
  templateUrl: './client.component.html',
  styleUrls: ['./client.component.css']
})
export class ClientComponent implements OnInit {
  pestanaSeleccionada: String = "uno";
  constructor() { }

  ngOnInit() {
  }

  cambiarPestana(value: String) {

    this.pestanaSeleccionada = value;
  }
}
