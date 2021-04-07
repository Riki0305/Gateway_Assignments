import { async, fakeAsync, TestBed, tick } from '@angular/core/testing';

import { CompanyService } from './company.service';

describe('CompanyService', () => {
  let service: CompanyService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(CompanyService);
  });

  it('should retrun length of the company data using async', async()=>{
    const data = await service.getCompanies();
    expect(data.length).toBe(3);

  });

  it('should return the length of company data using done',(done)=>{
    service.getCompanies().then(res=>{
      expect(res.length).toBe(3);
    });
    done();
  });

  it('should return the length of company data using fakeAsync',fakeAsync(()=>{
    tick();
    service.getCompanies().then(res=>{
      expect(res.length).toBe(3);
    })
  }));

  it('should return comany by Id using async',async()=>{
    const company = await service.getCompanyById(2);
    expect(company.id).toBe(2);
  });

  it('should return company by Id using done', (done)=>{
    service.getCompanyById(2).then(res=>{
      expect(res.id).toBe(2);
    });
    done();
  });

  it('should return company by Id using fakeAsync',fakeAsync(()=>{
    tick();
    service.getCompanyById(2).then(res=>{
      expect(res.id).toBe(2);
    })
  }))
});
