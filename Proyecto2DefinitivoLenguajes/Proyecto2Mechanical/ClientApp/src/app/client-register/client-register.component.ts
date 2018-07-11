import { Component, OnInit } from '@angular/core';
import { Client } from '../model/client.model';

import { Router } from '@angular/router';
import { ClientService } from '../service/client.service';

@Component({
  selector: 'app-client-register',
  templateUrl: './client-register.component.html',
  styleUrls: ['./client-register.component.css']
})
export class ClientRegisterComponent implements OnInit {
  formularioInsertar: boolean;
  formulario:boolean;
  client: Client = new Client();
  clients: Client[] = new Array<Client>();
    constructor(private router: Router, private service: ClientService) { }
  
    ngOnInit() {
      this.formulario=true;
    }
  
    insertClient(){
      this.service.insertClient(this.client).subscribe(
        (data: Client[] ) => {
          this.clients = data;
        }
      );
    }
  
    mostrarFormularioVehiculo() {
      this.formulario=false;
      this.formularioInsertar = true;
    }
}
