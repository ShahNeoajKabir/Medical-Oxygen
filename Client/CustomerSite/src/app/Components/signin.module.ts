import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { SignInComponent } from './sign-in/sign-in.component';
import { SigninRoutingModule } from './sigin-routing.module';
import { UserService } from '../Services/User/user.service';
import { SecurityService } from '../Services/security.service';
import { RegistrationComponent } from './registration/registration.component';



@NgModule({
  declarations: [ SignInComponent, RegistrationComponent],
  imports: [
    CommonModule,
    SigninRoutingModule,
    FormsModule
  ],
  providers:[SecurityService,UserService ],
})
export class SigninModule { }
