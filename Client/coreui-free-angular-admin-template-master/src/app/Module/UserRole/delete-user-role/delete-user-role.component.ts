import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Status } from '../../../Common/Enum';
import { Utility } from '../../../Common/Utility';
import { UserRole } from '../../../Model/UserRole';
import { NotificationService } from '../../../Services/Notification/notification.service';
import { RoleService } from '../../../Services/Role/role.service';
import { UserRoleService } from '../../../Services/User Role/user-role.service';
import { UserService } from '../../../Services/User/user.service';

@Component({
  selector: 'app-delete-user-role',
  templateUrl: './delete-user-role.component.html',
  styleUrls: ['./delete-user-role.component.scss']
})
export class DeleteUserRoleComponent implements OnInit {
  public objuserrole:UserRole=new UserRole();
  public edituserrole:UserRole=new UserRole();
  public lstuser:any;
  public lstrole:any;
  public lstStatus:any;
  constructor(
    private userroleservice:UserRoleService,
    private userservice:UserService,
    private utility:Utility ,
    private activatedroute:ActivatedRoute,
    private router:Router,
    private roleservice:RoleService,
    private notification:NotificationService
  ) { }

  ngOnInit(): void {

    this.lstStatus=this.utility.enumToArray(Status);

    this.userservice.GetAll().subscribe((res:any)=>{
      this.lstuser=res;
      console.log(this.lstuser);
    });
    this.roleservice.ActiveRole().subscribe((res:any)=>{
      this.lstrole=res;
      console.log(this.lstrole);
    });

    if (this.activatedroute.snapshot.params[ 'id'] !== undefined) {
      this.edituserrole.UserRoleId = this.activatedroute.snapshot.params[ 'id'];
      this.userroleservice.GetById(this.edituserrole).subscribe((res: any) => {
        this.objuserrole = res;
        console.log(this.objuserrole);
      });
      console.log(this.activatedroute.snapshot.params[ 'id']);
    }
  }

  DeleteUserRole(){
    this.userroleservice.DeleteUserRole(this.objuserrole).subscribe(res=>{
      console.log(res);
      if(res){
        this.notification.showDelete("","");
        this.router.navigate(['/UserRole/View']);
      }
    },er=>{
      this.notification.showError("","");
    })
  }

}
