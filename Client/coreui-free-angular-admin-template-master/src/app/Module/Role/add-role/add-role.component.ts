import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Status } from '../../../Common/Enum';
import { Utility } from '../../../Common/Utility';
import { Role } from '../../../Model/Role';
import { NotificationService } from '../../../Services/Notification/notification.service';
import { RoleService } from '../../../Services/Role/role.service';

@Component({
  selector: 'app-add-role',
  templateUrl: './add-role.component.html',
  styleUrls: ['./add-role.component.scss']
})
export class AddRoleComponent implements OnInit {
  public objrole:Role=new Role();
  public lstStatus:any;

  constructor(private roleservice:RoleService,private utility:Utility,private router:Router,private Notification:NotificationService) { }

  ngOnInit(): void {
    this.lstStatus=this.utility.enumToArray(Status);
  }
  AddRole(){
    this.roleservice.AddRole(this.objrole).subscribe(res=>{
      this.Notification.showSuccess("","");
      this.router.navigate(['/Role/ActiveRole']);
    },er=>{
      this.Notification.showError("","");
      this.router.navigate(['/Role/AddRole']);
    })

  }

}
