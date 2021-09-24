import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { UserRole } from '../../../Model/UserRole';
import { UserRoleService } from '../../../Services/User Role/user-role.service';

@Component({
  selector: 'app-list-user-role',
  templateUrl: './list-user-role.component.html',
  styleUrls: ['./list-user-role.component.scss']
})
export class ListUserRoleComponent implements OnInit {

  public lstuserrole:UserRole[]=new Array<UserRole>();

  constructor(private userroleservice:UserRoleService , private router:Router ) { }

  ngOnInit(): void {
    this.userroleservice.ActiveUserRole().subscribe((res:any)=>{
      this.lstuserrole=res;
      console.log(res);
    })
  }

}
