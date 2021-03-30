import { Component, OnInit } from '@angular/core';
import * as $ from "jquery";

import { DashboardService } from './dashboard.service';
@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit {

companies$;
  constructor(public service:DashboardService) { }

  ngOnInit(): void {
   this.service.getCompanyDetails()
   .subscribe(res=>{
     this.service.companies = res;
     console.log(res);
   })
  }

  toggleNavbar()
  {
    $("#bodyForMenu").toggleClass("sb-sidenav-toggled");
  }

}
