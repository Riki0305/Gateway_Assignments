import { Component, OnInit } from '@angular/core';
import { AuthService } from '../auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  constructor(private auth:AuthService) { }

  ngOnInit(): void {
  }

  needsLogin()
  {
    return !this.auth.isAuthenticated();
  }

  validateEmail(email:any){
    return this.auth.isValidEmail(email);
  }


  validatePassword(password:any){
   return this.auth.isValidPassword(password);
  }

  AuthorizeUser(email:any, password:any){
    return this.auth.isAuthorizedUser(email,password);
  }
}
