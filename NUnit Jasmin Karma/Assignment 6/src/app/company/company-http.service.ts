import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Company } from './company';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CompanyHttpService {

  companyCount=0;
  showCompany:Company=new Company();
  editCompany:Company=new Company();
  company : Company;

  constructor(private http:HttpClient) { }

  getAllCompanies():Observable<Company[]>
  {
   return this.http.get<Company[]>("http://localhost:3000/companies");

  }
  getCompanyById(id:number):Observable<Company>
  {
    return this.http.get<Company>("http://localhost:3000/companies/"+id.toString());
  }
  postCompany(body : Company):Observable<Company>
  {
    return this.http.post<Company>("http://localhost:3000/companies",body,{headers:{"content-Type":"application/json"}});
  }
  putCompany(body:Company):Observable<Company>
  {
    return this.http.put<Company>("http://localhost:3000/companies/"+body.id.toString(),body,{headers:{"content-Type":"application/json"}});
  }
  deleteCompany(id:number):Observable<Company>
  {
   return this.http.delete<Company>("http://localhost:3000/companies/"+id.toString());
  }
}
