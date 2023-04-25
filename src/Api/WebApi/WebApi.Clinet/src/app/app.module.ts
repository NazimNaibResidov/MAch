import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AppComponent } from './app.component';
import { CreatecommentComponent } from './components/comments/createcomment/createcomment/createcomment.component';
import { ListcommentComponent } from './components/comments/listcomment/listcomment/listcomment.component';
import { LoginComponent } from './components/users/login/login/login.component';
import { AuthInterceptor } from './interceptors/auth.interceptor';
import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';
import { RoutingModule } from './routing.module';
import { ErrorComponent } from './components/error/error.component';

@NgModule({
  declarations: [
    AppComponent,
    CreatecommentComponent,
    ListcommentComponent,
    LoginComponent,
    ErrorComponent,
   
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule,
    ReactiveFormsModule,
    RoutingModule
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: AuthInterceptor, multi: true },
    { provide: "baseUrl", useValue: "https://localhost:7129", multi: true }],
  bootstrap: [AppComponent]
})
export class AppModule { }
