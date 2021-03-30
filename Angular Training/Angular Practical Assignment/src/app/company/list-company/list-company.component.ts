import { Component, OnDestroy, OnInit, ViewChild } from '@angular/core';
import { Router } from '@angular/router';
import { Company } from '../company';
import { CompanyService } from '../company.service';
import { ListService } from './list.service';
import Swal from 'sweetalert2'
import * as Chart from 'chart.js';
import { Subject } from 'rxjs';
import { DataTableDirective } from 'angular-datatables';

@Component({
  selector: 'app-list-company',
  templateUrl: './list-company.component.html',
  styleUrls: ['./list-company.component.css']
})
export class ListCompanyComponent implements OnInit,OnDestroy {

  ngOnDestroy(): void {
    console.log('on destroy');

     this.dtTrigger.unsubscribe();
  }
  @ViewChild(DataTableDirective) dtElement :DataTableDirective;
  dtTrigger: Subject<any> = new Subject<any>();
  dtOptions: DataTables.Settings = {};
  flagTable=0;

  constructor(public service:ListService,private companyService:CompanyService,private route:Router) { }

  ngOnInit(): void {
    this.flagTable=0;
    this.refreshCompanyList();

    this.dtOptions = {
      pagingType: 'full_numbers',
      pageLength: 10
    };
  }
  refreshCompanyList()
  {
    this.service.getCompanyDetails()
    .subscribe(res=>{
      this.service.companies = res;
      console.log(res);
      if(this.flagTable == 0)
      {
        this.dtTrigger.next();
        this.flagTable = 1
      }
      else
      {
        this.rerender();
      }
    })
  }
  onView(company:Company)
  {
   this.companyService.showCompany = company;
  }
  onEdit(company:Company)
  {
    this.companyService.editCompany = company;
    this.route.navigate(['/company/edit']);
  }

  rerender()
  {
     this.dtElement.dtInstance.then((dtInstance : DataTables.Api)=>{
       dtInstance.clear().draw();
       dtInstance.destroy();
       this.dtTrigger.next();
     });
  }
  onDelete(id:number)
  {
    Swal.fire({
      title: 'Are you sure?',
      text: "You won't be able to revert this!",
      icon: 'warning',
      showCancelButton: true,
      confirmButtonColor: '#3085d6',
      cancelButtonColor: '#d33',
      confirmButtonText: 'Yes, delete it!'
    }).then((result) => {
      if (result.isConfirmed) {
        this.service.deleteCompany(id)
    .subscribe(res=>{
      console.log(res);
      this.refreshCompanyList();
    })

        Swal.fire(
          'Deleted!',
          'Your file has been deleted.',
          'success'
        )
      }
    })

  }


}
