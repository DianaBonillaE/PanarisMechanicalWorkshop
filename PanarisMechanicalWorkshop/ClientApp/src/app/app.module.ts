import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';

//pdf import
import { PDFExportModule } from '@progress/kendo-angular-pdf-export';


//ng select
import { NgSelectModule, NG_SELECT_DEFAULT_CONFIG } from '@ng-select/ng-select';
import { ProductComponent } from './product/product.component';
import { ReportComponent } from './report/report.component';
import { ClientComponent } from './client/client.component';
import { ClientListComponent } from './client/client-list/client-list.component';
import { ClientEditComponent } from './client/client-edit/client-edit.component';
import { ClientRegisterComponent } from './client-register/client-register.component';
import { WorkOrderComponent } from './work-order/work-order.component';
import { DetailWorkComponent } from './detail-work/detail-work.component';
import { VehicleDetailComponent } from './vehicle-detail/vehicle-detail.component';


@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    ProductComponent,
    ReportComponent,
    ClientComponent,
    ClientListComponent,
    ClientEditComponent,
    ClientRegisterComponent,
    WorkOrderComponent,
    DetailWorkComponent,
    VehicleDetailComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    PDFExportModule,
    NgSelectModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'counter', component: CounterComponent },
      { path: 'fetch-data', component: FetchDataComponent },
      { path: 'report', component: ReportComponent },
      { path: 'product', component: ProductComponent }

    ])
  ],
  providers: [{
    provide: NG_SELECT_DEFAULT_CONFIG,
    useValue: {
        notFoundText: 'Este registro no es valido.'
    }
}],
  bootstrap: [AppComponent]
})
export class AppModule { }
