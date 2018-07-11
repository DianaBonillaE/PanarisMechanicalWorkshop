import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';


//pdf import
import { PDFExportModule } from '@progress/kendo-angular-pdf-export';



import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { ClientComponent } from './client/client.component';
import { ClientEditComponent } from './client/client-edit/client-edit.component';
import { ClientListComponent } from './client/client-list/client-list.component';
import { ClientRegisterComponent } from './client-register/client-register.component';
import { DetailWorkComponent } from './detail-work/detail-work.component';
import { ProductComponent } from './product/product.component';
import { ReportComponent } from './report/report.component';
import { VehicleDetailComponent } from './vehicle-detail/vehicle-detail.component';
import { WorkOrderComponent } from './work-order/work-order.component';


//ng select
import { NgSelectModule, NG_SELECT_DEFAULT_CONFIG } from '@ng-select/ng-select';
import { ClientService } from './service/client.service';
import { Client } from './model/client.model';
import { WorkDetailOrderService } from './service/work-detail-order.service';
import { WorkOrderService } from './service/work-order.service';
import { VehicleInsertComponent } from './vehicle-insert/vehicle-insert.component';
import { VehicleService } from './service/vehicle-service';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    ClientComponent,
    ClientEditComponent,
    ClientListComponent,
    ClientRegisterComponent,
    DetailWorkComponent,
    ProductComponent,
    ReportComponent,
    VehicleDetailComponent,
    WorkOrderComponent,
    VehicleInsertComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    FormsModule,
    HttpClientModule,
    PDFExportModule,
    NgSelectModule,
    RouterModule.forRoot([
      { path: 'report', component: ReportComponent },
      { path: 'product', component: ProductComponent },
      { path: 'detail-work', component: DetailWorkComponent },
      { path: 'work-order', component: WorkOrderComponent },
      { path: 'vehicle-detail', component: VehicleDetailComponent },
      { path: 'client', component: ClientComponent },
      { path: 'client-list', component: ClientListComponent },
      { path: 'client-edit', component: ClientEditComponent },
      { path: 'register-client', component: ClientRegisterComponent },
      { path: 'register-vehicle', component: VehicleInsertComponent }

    ])
  ],
  providers: [{
    provide: NG_SELECT_DEFAULT_CONFIG,
    useValue: {
      notFoundText: 'Este registro no es valido.'
    }
  }, ClientService, WorkDetailOrderService, WorkOrderService, VehicleService],
  bootstrap: [AppComponent]
})
export class AppModule { }
