import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { CompanyRoutingModule } from './company-routing.module';
import { CompanyComponent } from './company.component';
import { ListCompanyComponent } from './list-company/list-company.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { AddCompanyComponent } from './add-company/add-company.component';
import { EditCompanyComponent } from './edit-company/edit-company.component';
import { ViewCompanyComponent } from './view-company/view-company.component';
import { ReactiveFormsModule } from '@angular/forms';
import { RxReactiveFormsModule } from '@rxweb/reactive-form-validators';
import { ChartsModule } from 'ng2-charts';
import { DataTablesModule } from 'angular-datatables';


@NgModule({
  declarations: [CompanyComponent, ListCompanyComponent, DashboardComponent, AddCompanyComponent, EditCompanyComponent, ViewCompanyComponent],
  imports: [
    CommonModule,
    CompanyRoutingModule,
    ReactiveFormsModule,
    RxReactiveFormsModule,
    ChartsModule,
    DataTablesModule,
  ]
})
export class CompanyModule { }
