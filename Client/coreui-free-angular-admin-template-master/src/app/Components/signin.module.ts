import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { SignInComponent } from './sign-in/sign-in.component';
import { SigninRoutingModule } from './sigin-routing.module';
import { ChangePasswordComponent } from './change-password/change-password.component';
import { UserService } from '../Services/User/user.service';
import { SecurityService } from '../Services/security.service';



@NgModule({
  declarations: [ SignInComponent, ChangePasswordComponent],
  imports: [
    CommonModule,
    SigninRoutingModule,
    FormsModule
  ],
  providers:[SecurityService,UserService ],
})
export class SigninModule { }
