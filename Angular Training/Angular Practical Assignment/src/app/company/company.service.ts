import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Company } from './company';

@Injectable({
  providedIn: 'root'
})
export class CompanyService {

  companyCount=0;
  showCompany:Company=new Company();
  editCompany:Company=new Company();
  company : Company;
  constructor(private http:HttpClient) { }

  getCompanyCount():number
  {
     this.http.get<Company[]>("http://localhost:3000/companies")
     .subscribe(res=>{
       console.log(res);
        this.companyCount = res.length;
        this.companyCount++;
        console.log(this.companyCount);
     })
     return 0;
  }
  postCompany(body : Company)
  {
    return this.http.post<Company>("http://localhost:3000/companies",body,{headers:{"content-Type":"application/json"}});
  }
  putCompany(body:Company)
  {
    return this.http.put<Company>("http://localhost:3000/companies/"+body.id.toString(),body,{headers:{"content-Type":"application/json"}});
  }
}
