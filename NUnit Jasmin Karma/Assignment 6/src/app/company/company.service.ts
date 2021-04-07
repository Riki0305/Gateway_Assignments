import { Injectable } from '@angular/core';
import { async } from '@angular/core/testing';
import { Company } from './company';

@Injectable({
  providedIn: 'root'
})
export class CompanyService {

  company :Company[]= [
    {
      "id": 1,
      "email": "zomato@gmail.com",
      "name": "zomato",
      "totalEmployee": 2000,
      "address": "Mumbai",
      "isCompanyActive": false,
      "companyBranch": [
        {
          "id": 1,
          "name": "Zomato Mumbai",
          "address": "Mumbai"
        },
        {
          "id": 2,
          "name": "Zomato Ahmedabad",
          "address": "Ahmedabad"
        },
        {
          "id": 3,
          "name": "Zomato Navi Mumbai",
          "address": "Navi Mumbai"
        },
        {
          "id": 4,
          "name": "Zomato Anand",
          "address": "Anand"
        }
      ],
      "totalBranch": 4
    },
    {
      "id": 2,
      "email": "uber@gmail.com",
      "name": "Uber",
      "totalEmployee": 200,
      "address": "Ahmedabad",
      "isCompanyActive": false,
      "companyBranch": [
        {
          "id": 1,
          "name": "Uber Ahmedabad",
          "address": "Ahmedabad"
        },
        {
          "id": 2,
          "name": "Uber Baroda ",
          "address": "Baroda"
        }
      ],
      "totalBranch": 2
    },
    {
      "id": 3,
      "email": "ola@gmail.com",
      "name": "Ola",
      "totalEmployee": 500,
      "address": "Ahmedabad",
      "isCompanyActive": true,
      "companyBranch": [
        {
          "id": 1,
          "name": "Ola Ahmedabad",
          "address": "Ahmedabad"
        },
        {
          "id": 2,
          "name": "Ola Rajkot",
          "address": "Rajkot"
        },
        {
          "id": 3,
          "name": "Ola Maisur",
          "address": "Maisur"
        },
        {
          "id": 4,
          "name": "Ola Anand",
          "address": "Anand"
        }
      ],
      "totalBranch": 4
    }
  ];
  constructor() { }


  getCompanies = async()=>{
    return this.company;
  }

  getCompanyById = async(id)=>{
    for(let i=0;i<this.company.length;i++)
    {
      if(this.company[i].id == id)
      {
        return this.company[i];
      }
    }
  }
}
