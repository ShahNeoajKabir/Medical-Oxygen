import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Status, UserType } from 'src/app/Common/Enum';
import { Utility } from 'src/app/Common/Utility';
import { User } from 'src/app/Model/User';
import { NotificationService } from 'src/app/Services/Notification/notification.service';
import { UserService } from 'src/app/Services/User/user.service';

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.css']
})
export class RegistrationComponent implements OnInit {

  public objuser:User=new User();
  public lstStatus:any;
  public lstusertype:any;

  constructor(private userService:UserService,private router:Router, private utility:Utility, private ActivateRouter:ActivatedRoute,private notification:NotificationService
    ,private toast:ToastrService
    ) { }

  ngOnInit(): void {
    this.lstStatus=this.utility.enumToArray(Status);
    this.lstusertype=this.utility.enumToArray(UserType);
  }
  Registration(){
    console.log(this.objuser);
    
      this.userService.Registration(this.objuser).subscribe(res => {
        this.toast.success("Registration Successfull");
        this.router.navigate(['/security/Login']);
        
      },er=>{
        this.toast.error("Invalid Request Try Again");
        this.router.navigate(['/security/Registration']);
      } );
  }

  

}
