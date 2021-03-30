import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Company } from '../company';

@Injectable({
  providedIn: 'root'
})
export class ListService {


  companies:Company[]=[];
  constructor(private http:HttpClient) { }

  getCompanyDetails():Observable<Company[]>
  {
   return this.http.get<Company[]>("http://localhost:3000/companies");

  }

  deleteCompany(id:number)
  {
   return this.http.delete("http://localhost:3000/companies/"+id.toString());
  }
}
