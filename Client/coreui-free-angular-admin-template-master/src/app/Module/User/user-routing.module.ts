

import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ToastrModule } from 'ngx-toastr';
import { AddUserComponent } from './add-user/add-user.component';
import { AllUserListComponent } from './all-user-list/all-user-list.component';
import { CustomerlisComponent } from './customerlis/customerlis.component';
import { DeleteUserComponent } from './delete-user/delete-user.component';
import { DeliverymanListComponent } from './deliveryman-list/deliveryman-list.component';
import { ModeratorListComponent } from './moderator-list/moderator-list.component';
import { UpdateUserComponent } from './update-user/update-user.component';


const routes: Routes = [
    { 
        path: '',
    data: {
      title: 'User'
    },
    children: [
      {
        path: '',
        redirectTo: 'ListAllUser'
      },
      {
        path: 'AddUser',
        component: AddUserComponent,
        data: {
          title: 'AddUser'
        }
      },
      {
        path: 'ListAllUser',
        component: AllUserListComponent,
        data: {
          title: 'ListAllUser'
        }
      },
      {
          path:'Moderator',
          component:ModeratorListComponent,
          data:{
              title:'Moderator',
          }
      },
        {
        path:'DeliveryMan',
        component:DeliverymanListComponent,
        data:{
            title:'DeliveryMan',
        }
        },
        {
        path:'Customer',
        component:CustomerlisComponent,
        data:{
            title:'Customer',
        }
        },

        {
            path:':id/edit',
            component:UpdateUserComponent,
            data:{
                title:':id/edit',
            }
        },
        {
            path:':id/delete',
            component:DeleteUserComponent,
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
export class UserRoutingModule { }