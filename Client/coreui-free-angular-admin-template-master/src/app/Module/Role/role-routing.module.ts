

import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ToastrModule } from 'ngx-toastr';
import { ActiveRoleListComponent } from './active-role-list/active-role-list.component';
import { AddRoleComponent } from './add-role/add-role.component';
import { DeactiveRoleListComponent } from './deactive-role-list/deactive-role-list.component';
import { DeleteRoleComponent } from './delete-role/delete-role.component';
import { UpdateRoleComponent } from './update-role/update-role.component';


const routes: Routes = [
    { 
        path: '',
    data: {
      title: 'Role'
    },
    children: [
      {
        path: '',
        redirectTo: 'ActiveRole'
      },
      {
        path: 'AddRole',
        component: AddRoleComponent,
        data: {
          title: 'AddRole'
        }
      },
      {
        path: 'ActiveRole',
        component: ActiveRoleListComponent,
        data: {
          title: 'ActiveRole'
        }
      },
      {
          path:'DeactiveRole',
          component:DeactiveRoleListComponent,
          data:{
              title:'DeactiveRole',
          }
      },

        {
            path:':id/edit',
            component:UpdateRoleComponent,
            data:{
                title:':id/edit',
            }
        },
        {
            path:':id/delete',
            component:DeleteRoleComponent,
            data:{
                title:':id/delete',
            }
        },
    ]
}



];

@NgModule({
  imports: [RouterModule.forChild(routes), ToastrModule.forRoot()],
  exports: [RouterModule]
})
export class RoleRoutingModule { }