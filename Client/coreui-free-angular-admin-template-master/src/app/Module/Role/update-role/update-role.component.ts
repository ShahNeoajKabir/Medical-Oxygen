import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Status } from '../../../Common/Enum';
import { Utility } from '../../../Common/Utility';
import { Role } from '../../../Model/Role';
import { NotificationService } from '../../../Services/Notification/notification.service';
import { RoleService } from '../../../Services/Role/role.service';

@Component({
  selector: 'app-update-role',
  templateUrl: './update-role.component.html',
  styleUrls: ['./update-role.component.scss']
})
export class UpdateRoleComponent implements OnInit {
  public objrole:Role=new Role();
  public editrole:Role=new Role();
  public lstStatus:any;

  public userid:any;

  constructor(private roleservice:RoleService,private utility:Utility, private router:Router, private httpclient:HttpClient,private ActivateRouter:ActivatedRoute, private notification:NotificationService) { }

  ngOnInit(): void {
    this.lstStatus=this.utility.enumToArray(Status);


    if (this.ActivateRouter.snapshot.params['id'] !== undefined) {

      this.editrole.RoleId = this.ActivateRouter.snapshot.params['id' ];
      this.roleservice.GetById(this.editrole).subscribe(( res: any) => {

        this.objrole = res;
        console.log(res);
     });
      console.log(this.ActivateRouter.snapshot.params['id' ] );

    }
  }

  UpdateRole(){
    this.roleservice.UpdateRole(this.objrole).subscribe(res=>{
      console.log(res);
      if(res){
        this.notification.showUpdate("","");
        this.router.navigate(['/Role/ActiveRole']);
      }
    },er=>{
      this.notification.showError("","");
      this.router.navigate(['/Role/ActiveRole']);
    })
  }

}
