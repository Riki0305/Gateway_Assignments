import { ComponentFixture, TestBed } from '@angular/core/testing';
import { AuthService } from '../auth.service';

import { LoginComponent } from './login.component';

class MockAuthService extends AuthService{
  authenticated = false;

  isAuthenticated()
  {
    return this.authenticated;
  }

}

describe('LoginComponent', () => {
  let component: LoginComponent;
  let service : MockAuthService;
  let spy : any;

  beforeEach(()=>{
    service = new MockAuthService();
    component = new LoginComponent(service);
  })

  afterEach(()=>{
    localStorage.removeItem('token');
    service = null;
    component = null;
  })

  //needsLogin [Positive]
  it('needsLogin return true if user is not authenticated',()=>{
    spy = spyOn(service,'isAuthenticated').and.returnValue(false);
    expect(component.needsLogin()).toBeTruthy();
  })

  //needsLogin [Negative]
  it('needsLogin returns false when user is authenticated',()=>{
    spy = spyOn(service,'isAuthenticated').and.returnValue(true);
    expect(component.needsLogin()).toBeFalsy();
  })

  //validate Email [Positive]
  it('validateEmail return true if email is valid',()=>{
   spy = spyOn(service,'isValidEmail').and.returnValue(true);
   expect(component.validateEmail("rikinpatel@gmail.com")).toBeTruthy();
  })

   //validate Email [Negative]
   it('validateEmail return false if email is invalid',()=>{
    spy = spyOn(service,'isValidEmail').and.returnValue(false);
    expect(component.validateEmail("rikinpatel@gmail.com")).toBeFalsy();
   })

   //validate Password [Positive]
  it('validatePassword return true if Password is valid',()=>{
    spy = spyOn(service,'isValidPassword').and.returnValue(true);
    expect(component.validatePassword("R!k!n1234")).toBeTruthy();
   })

    //validate Password [Negative]
    it('validatePassword return false if Password is invalid',()=>{
     spy = spyOn(service,'isValidPassword').and.returnValue(false);
     expect(component.validatePassword("R!k!n1234")).toBeFalsy();
    })

     //validate User [Positive]
  it('AuthorizeUser return true if User is valid',()=>{
    spy = spyOn(service,'isAuthorizedUser').and.returnValue(true);
    expect(component.AuthorizeUser("rikinpatel@gmail.com","R!k!n1234")).toBeTruthy();
   })

    //validate User [Negative]
    it('AuthorizeUser return false if User is invalid',()=>{
     spy = spyOn(service,'isAuthorizedUser').and.returnValue(false);
     expect(component.AuthorizeUser("rikinpatel@gmail.com","R!k!n1234")).toBeFalsy();
    })
});
