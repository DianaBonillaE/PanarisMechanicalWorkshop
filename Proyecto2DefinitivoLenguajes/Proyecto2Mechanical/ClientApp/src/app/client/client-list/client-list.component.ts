import { Component, OnInit, Output } from '@angular/core';
import { Client } from '../../model/client.model';
import {Router} from '@angular/router';
import { ClientService } from '../../service/client.service';
import { EventEmitter } from 'events';



@Component({
  selector: 'app-client-list',
  templateUrl: './client-list.component.html',
  styleUrls: ['./client-list.component.css']
})
export class ClientListComponent implements OnInit {
  @Output() dataByOutput = new EventEmitter();

  clients: Client[] = new Array<Client>();
    constructor(private router: Router, private service: ClientService){
      
    }
    client: Client = new Client();
  pestanaSeleccionada: string;

  ngOnInit() {

   this.service.getAll().subscribe((data: Client[]) => {
     this.clients = data;
    });
  }

  click(client: Client) {
    localStorage.setItem('client', JSON.stringify(client));
  }

  cambiarAEditar() {
    localStorage.setItem('editar', 'edit');
  }

  metodo() {
    this.dataByOutput.emit("Hijo");
  }
  }

