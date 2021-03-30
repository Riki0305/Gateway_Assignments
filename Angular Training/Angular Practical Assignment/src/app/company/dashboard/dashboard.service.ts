import { HttpClient, HttpClientModule } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Company } from '../company';

@Injectable({
  providedIn: 'root'
})
export class DashboardService {

  companies:Company[]=[];
  constructor(private http:HttpClient) { }

  getCompanyDetails():Observable<Company[]>
  {
   return this.http.get<Company[]>("assets/company.json");

  }
}
