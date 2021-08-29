import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Status } from '../../../Common/Enum';
import { Utility } from '../../../Common/Utility';
import { Role } from '../../../Model/Role';
import { NotificationService } from '../../../Services/Notification/notification.service';
import { RoleService } from '../../../Services/Role/role.service';

@Component({
  selector: 'app-delete-role',
  templateUrl: './delete-role.component.html',
  styleUrls: ['./delete-role.component.scss']
})
export class DeleteRoleComponent implements OnInit {

  public objrole:Role=new Role();
  public deleterole:Role=new Role();
  public lstStatus:any;

  constructor(private roleservice:RoleService,private utility:Utility, private router:Router,private ActivateRouter:ActivatedRoute, private notification:NotificationService) { }

  ngOnInit(): void {
    this.lstStatus=this.utility.enumToArray(Status);



    if (this.ActivateRouter.snapshot.params['id'] !== undefined) {

      this.deleterole.RoleId = this.ActivateRouter.snapshot.params['id' ];
      this.roleservice.GetById(this.deleterole).subscribe(( res: any) => {

        this.objrole = res;
        console.log(res);
     });
      console.log(this.ActivateRouter.snapshot.params['id' ] );

    }
  }

  DeleteRole(){
    this.roleservice.DeleteRole(this.objrole).subscribe(res=>{
      console.log(res);
      if(res){
        this.notification.showDelete("","");
        this.router.navigate(['/Role/ActiveRole']);
      }
    },er=>{
      this.notification.showError("","");
      this.router.navigate(['/Role/ActiveRole']);
    })
  }

}
