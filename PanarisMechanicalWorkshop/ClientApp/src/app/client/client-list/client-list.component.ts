import { Component, OnInit } from '@angular/core';
import { Client } from '../../model/client.model';
import {Router} from '@angular/router';
import { ClientService } from '../client.service';


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
  //  this.service.getAll().subscribe((data: Client[]) => {
   //   this.clients = data;
    //});
    
    this.client.idClient='123';
    this.client.clientName='Fil';
    this.client.lastName='nkf';
    this.client.address='gujhi';
    this.client.phoneNumber='24555';
    this.client.email='krnjkg';

    this.clients.push(this.client);
    
  }

}
