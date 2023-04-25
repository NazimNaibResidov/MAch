import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { HttpClientService } from './Core/httpclient.service';
import { LoginModel } from '../models/componentsModul/login-model';
import { CreateUser } from '../models/componentsModul/create-user';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  isLoggedIn: boolean;
  constructor(
    private router: Router, private _http: HttpClientService) { }
  


  
  login(user: LoginModel) {
   
    return this.Core("User","Login",user);
                         
   }

  logout() {
    localStorage.removeItem("token");
    localStorage.clear();
    this.isLoggedIn=false;
    this.router.navigate(['/login']);
    localStorage.clear();
    this.isLoggedIn=true;
  }
  
  Registrtion(auth: CreateUser) {
    let result = this.Core('User', 'Registration', auth);
    return result;
  }

  private Core<T>(_controllerName: string , _actionName: string, data: T): Observable<T> {
    return this._http.post<T>(
      {
        controller: _controllerName,
        action: _actionName
      }, data);
  }
}
