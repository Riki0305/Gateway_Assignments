import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AddCompanyComponent } from './add-company/add-company.component';
import { CompanyComponent } from './company.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { EditCompanyComponent } from './edit-company/edit-company.component';
import { ListCompanyComponent } from './list-company/list-company.component';
import { ViewCompanyComponent } from './view-company/view-company.component';

const routes: Routes = [
  { path: '', component: DashboardComponent ,
    children:[
      {
        path:'',component:ListCompanyComponent
      },
      {
        path:'list',component:ListCompanyComponent
      },
      {
        path:'add',component:AddCompanyComponent
      },
      {
        path:'edit',component:EditCompanyComponent
      },
      {
        path:'view',component:ViewCompanyComponent
      }
    ]
},

];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class CompanyRoutingModule { }
