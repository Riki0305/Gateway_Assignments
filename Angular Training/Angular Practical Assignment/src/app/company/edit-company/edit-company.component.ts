import { Component, OnInit } from '@angular/core';
import { FormArray, FormBuilder, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { RxFormBuilder } from '@rxweb/reactive-form-validators';
import { Company } from '../company';
import { CompanyService } from '../company.service';
import Swal from 'sweetalert2'

@Component({
  selector: 'app-edit-company',
  templateUrl: './edit-company.component.html',
  styleUrls: ['./edit-company.component.css']
})
export class EditCompanyComponent implements OnInit {

  company:Company=new Company();

  companyForm : FormGroup
  // companyForm = this.fb.group({
  //   id:[''],
  //   email:[''],
  //   name:[''],
  //   totalEmployee:[''],
  //   address:[''],
  //   isCompanyActive:[''],
  //   companyBranch:this.fb.array([])

  // })

  constructor(private fb:FormBuilder,private service:CompanyService,private formBuilder:RxFormBuilder,private route:Router) { }

  ngOnInit(): void {
    // this.company={
    //   id: 1,
    //   email: "zomato@gmail.com",
    //   name: "zomato",
    //   totalEmployee: 2000,
    //   address: "Mumbai",
    //   isCompanyActive: true,
    //   totalBranch: 3,
    //   companyBranch: [
    //     {
    //       id: 1,
    //       name: "zomato1",
    //       address: "anand"
    //     },
    //     {
    //       id: 2,
    //       name: "zomato2",
    //       address: "amdvd"
    //     },
    //     {
    //       id: 3,
    //       name: "zomato3",
    //       address: "mumbai"
    //     }
    //   ]
    // }
    if(this.service.editCompany.id == 0)
    {
      this.route.navigate(['/company']);
    }
    this.companyForm = this.formBuilder.formGroup(Company,this.service.editCompany);
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
    console.log(this.companyForm.value);
    console.log(company);
    this.service.putCompany(company)
    .subscribe(res=>{
      console.log(res);
      this.route.navigate(['/company']);
      Swal.fire(
        'Updated!',
        'Company has been updated.',
        'success'
      )
    })
  }


}
