import { Component, OnInit, Output } from '@angular/core';
import { Client } from '../../model/client.model';
import { Local } from 'protractor/built/driverProviders';
import { Router } from '@angular/router';
import { ClientService } from '../../service/client.service';

@Component({
  selector: 'app-client-edit',
  templateUrl: './client-edit.component.html',
  styleUrls: ['./client-edit.component.css']
})
export class ClientEditComponent implements OnInit {
  cliente: Client = new Client;
  constructor(private router: Router, private service: ClientService) { }


  ngOnInit() {
    //console.log(JSON.parse(localStorage.getItem('cliente'));
    if (localStorage.getItem('client') != null) {
      this.cliente=(JSON.parse(localStorage.getItem('client')));
    }
  }

  edit() {
    this.service.edit(this.cliente).subscribe(
      (data: Client) => {
      this.cliente = data;
      });
    localStorage.setItem('client', null);
  }
}
