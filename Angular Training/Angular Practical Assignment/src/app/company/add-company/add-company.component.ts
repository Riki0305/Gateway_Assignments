import { Component, OnInit } from '@angular/core';
import {FormArray, FormBuilder, Validators} from '@angular/forms';
import { Router } from '@angular/router';
import { Company } from '../company';
import { CompanyService } from '../company.service';
import Swal from 'sweetalert2'

@Component({
  selector: 'app-add-company',
  templateUrl: './add-company.component.html',
  styleUrls: ['./add-company.component.css']
})
export class AddCompanyComponent implements OnInit {


branchCount=4;

  companyForm = this.fb.group({
    id:[''],
    email:['',Validators.required],
    name:['',Validators.required],
    totalEmployee:['',Validators.required],
    address:['',Validators.required],
    isCompanyActive:['',Validators.required],
    companyBranch:this.fb.array([])

  })

  constructor(private fb:FormBuilder,private service:CompanyService,private route:Router) { }

  ngOnInit(): void {
    this.service.getCompanyCount();
  }

  get branches() {
    return this.companyForm.get('companyBranch') as FormArray;
  }

  addBranch() {
    this.branches.push(this.fb.group({name:'',address:''}));
  }

  deleteBranch(index) {
    this.branches.removeAt(index);
  }
  onSubmit(){

    var company : Company = this.companyForm.value;
    company.totalBranch = company.companyBranch.length;
    company.id=this.service.companyCount;
    this.service.companyCount++;
    console.log(company);
    this.service.postCompany(company)
    .subscribe(res=>{
      console.log(res);
      this.route.navigate(['/company']);
      Swal.fire(
        'Added!',
        'Company has been added.',
        'success'
      )

    })
  }
}
