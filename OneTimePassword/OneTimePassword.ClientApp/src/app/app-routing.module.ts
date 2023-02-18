import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { OneTimePasswordComponent } from './one-time-password/one-time-password.component';

const routes: Routes = [
    { path: 'OneTimePassword/:userId', component: OneTimePasswordComponent },
    { path: 'OneTimePassword', component: OneTimePasswordComponent },
    { path: '', component: HomeComponent }
];
@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }