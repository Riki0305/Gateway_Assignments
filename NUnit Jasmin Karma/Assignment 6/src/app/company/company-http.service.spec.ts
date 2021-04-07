import { HttpClient, HttpClientModule, HttpHandler } from '@angular/common/http';
import { fakeAsync, TestBed, tick } from '@angular/core/testing';
import { Company } from './company';

import { CompanyHttpService } from './company-http.service';

describe('CompanyHttpService', () => {
  let service: CompanyHttpService;


  beforeEach(() => {

    TestBed.configureTestingModule({
      imports:[HttpClientModule]
    });
    service = TestBed.inject(CompanyHttpService);
  });



  it('should return list of companies',(done)=>{
    service.getAllCompanies().subscribe(data=>{
      expect(data.length).toBe(5);
      done();
    })
  });

  it('should post a company',async()=>{
    let company= {
      "id": 5,
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
    };

    const result = service.postCompany(company);
    expect(result).toBeTruthy();
  });

  it('should update a company',async()=>{
    let company= {
      "id": 5,
      "email": "uber@gmail.com",
      "name": "Uber12",
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
    };

    const updatedCompany = service.putCompany(company);
    expect(updatedCompany).toBeTruthy();
  });


  it('should delete a company',async()=>{
    const company = service.deleteCompany(5);
    expect(company).toBeTruthy();
  });

  it('should get company by Id',(done)=>{
    const result = service.getCompanyById(1);
    expect(result).toBeTruthy();
    done();
  });

});
