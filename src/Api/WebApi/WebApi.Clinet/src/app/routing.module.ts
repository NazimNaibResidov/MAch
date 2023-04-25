import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LoginComponent } from './components/users/login/login/login.component';
import { RouterModule, Routes } from '@angular/router';
import { ListcommentComponent } from './components/comments/listcomment/listcomment/listcomment.component';
import { CreatecommentComponent } from './components/comments/createcomment/createcomment/createcomment.component';
import { LoginGuard } from './Guards/login.guard';
import { ErrorComponent } from './components/error/error.component';

const appRoutes: Routes = [


  { path:"", redirectTo:'/login', pathMatch: 'full' },
  { path: 'login', component: LoginComponent },
  { path: 'list_commet', component: ListcommentComponent, canActivate: [LoginGuard] },
  { path: 'create_comment', component: CreatecommentComponent, canActivate: [LoginGuard] },
  
  { path: '**', component: ErrorComponent }
];

@NgModule({
  imports: [
    CommonModule,
    RouterModule.forRoot(appRoutes)],

  declarations: [],
  exports: [RouterModule]
})
export class RoutingModule { }
