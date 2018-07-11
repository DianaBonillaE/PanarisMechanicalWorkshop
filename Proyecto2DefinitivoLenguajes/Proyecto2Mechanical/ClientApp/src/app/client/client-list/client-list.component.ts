import { Component, OnInit } from '@angular/core';
import { Client } from '../../model/client.model';
import {Router} from '@angular/router';
import { ClientService } from '../../service/client.service';



@Component({
  selector: 'app-client-list',
  templateUrl: './client-list.component.html',
  styleUrls: ['./client-list.component.css']
})
export class ClientListComponent implements OnInit {

  clients: Client[] = new Array<Client>();
    constructor(private router: Router, private service: ClientService){
      
    }
    client: Client = new Client();

  ngOnInit() {
   this.service.getAll().subscribe((data: Client[]) => {
     this.clients = data;
    });
  }

  click(client:Client){
    alert(client.clientName);
    
  }
  }

