import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot, UrlTree } from '@angular/router';
import { Observable } from 'rxjs';
import { AuthService } from '../services/auths.service';

@Injectable({
  providedIn: 'root'
})
export class LoginGuard implements CanActivate {
  constructor(private router:Router,
  private  auth:AuthService){}
  canActivate(
   
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree {
  //   debugger;
      let result=this.auth.isLoggedIn;
      if(!this.auth.isLoggedIn|| this.auth.isLoggedIn==undefined){
    this.router.navigate(['login']);
    return false;
   }
   else {
   
    return true;
   }

  }
  
}
