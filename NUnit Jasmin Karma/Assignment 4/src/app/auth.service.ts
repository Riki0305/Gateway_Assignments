import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor() { }

  isAuthenticated() :boolean
  {
    return !!localStorage.getItem('token');
  }

  isValidEmail(email) : boolean{
    const regex = /^[a-z0-9._%+-]+@[a-z0-9.-]+\\.[a-z]{2,4}$/;
    return regex.test(String(email).toLowerCase());
  }

  isValidPassword(password) : boolean{
    const regex = /(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}/;
    return regex.test(String(password));
  }

  isAuthorizedUser(email:any, password:any){
    if(email=="rikinpatel@gmail.com" && password=="R!k!n1234"){
      return true;
    }
    else
      return false;
  }
}
