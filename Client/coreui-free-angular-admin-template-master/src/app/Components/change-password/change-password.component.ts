import { THIS_EXPR } from '@angular/compiler/src/output/output_ast';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../../Common/Auth/auth.service';
import { VMChangePassword } from '../../Model/VMChangePassword';
import { NotificationService } from '../../Services/Notification/notification.service';
import { UserService } from '../../Services/User/user.service';

@Component({
  selector: 'app-change-password',
  templateUrl: './change-password.component.html',
  styleUrls: ['./change-password.component.css']
})
export class ChangePasswordComponent implements OnInit {
  public objvmpass:VMChangePassword=new VMChangePassword();

  constructor(private authservice:AuthService, private UserService:UserService, private notificationservice:NotificationService, private router:Router) { }

  ngOnInit(): void {
    this.objvmpass.Email=this.authservice.getLoggedEmail();
    this.objvmpass.UserId=this.authservice.getLoggedUserId();
  }
//   ChangePassword(){
    
//     this.UserService.ChangePassword(this.objvmpass).subscribe(res=>{
//     console.log(res);
//     if(res){
//       this.notificationservice.showSuccess("","");
//       this.router.navigate(['/dashboard']);
//     }

      
    

//     }, er=>{
//       this.notificationservice.showError("","");
//       this.router.navigate(['/ChangePassword']);
//     })
  
// }

}
