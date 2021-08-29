import { Component, OnInit } from '@angular/core';
import { Role } from '../../../Model/Role';
import { RoleService } from '../../../Services/Role/role.service';

@Component({
  selector: 'app-deactive-role-list',
  templateUrl: './deactive-role-list.component.html',
  styleUrls: ['./deactive-role-list.component.scss']
})
export class DeactiveRoleListComponent implements OnInit {
  public lstrole:Role[]=new Array<Role>();

  constructor(private roleservice:RoleService) { }

  ngOnInit(): void {
    this.roleservice.DeactivateRole().subscribe((res:any)=>{
      this.lstrole=res;
      console.log(res);
    })
  }

}
