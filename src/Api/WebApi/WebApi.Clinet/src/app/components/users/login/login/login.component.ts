import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, FormControl, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { LoginModel } from 'src/app/models/componentsModul/login-model';
import { AuthService } from 'src/app/services/auths.service';
@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  loginForm: FormGroup;

  constructor(private router: Router, private formBuilder: FormBuilder, private _http: AuthService) { }
  ngOnInit(): void {
    this.loadForm();

  }
  login() {

    if (this.loginForm.valid) {
      localStorage.removeItem('token');

      let converObject: LoginModel = Object.assign({}, this.loginForm.value);
      this._http.login(converObject)
        .subscribe((resp: any) => {
          this._http.isLoggedIn = true;

          localStorage.setItem('token', resp.token);
          this.router.navigate(['create_comment']);

        });
    }
  }
  //#region  ::HELPERS::
  private loadForm() {
    return this.loginForm = this.formBuilder.group({
      email: new FormControl("", Validators.required),
      password: new FormControl("", Validators.required)
    })
  }
  //#endregion
}
