import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Utility } from '../../../Common/Utility';
import { Role } from '../../../Model/Role';
import { RoleService } from '../../../Services/Role/role.service';

@Component({
  selector: 'app-active-role-list',
  templateUrl: './active-role-list.component.html',
  styleUrls: ['./active-role-list.component.scss']
})
export class ActiveRoleListComponent implements OnInit {
  public rolelist:Role[]=new Array<Role>();

  constructor(private roleservice:RoleService, private router:Router , private utility:Utility) { }

  ngOnInit(): void {
    this.roleservice.ActiveRole().subscribe((res:any)=>{
      this.rolelist=res;
    })
  }

}
