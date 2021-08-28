

import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ToastrModule } from 'ngx-toastr';
import { AddUserComponent } from './add-user/add-user.component';
import { AllUserListComponent } from './all-user-list/all-user-list.component';


const routes: Routes = [
    { 
        path: '',
    data: {
      title: 'User'
    },
    children: [
      {
        path: '',
        redirectTo: 'AddUser'
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
          title: 'AddUser'
        }
      }
    ]
}



];

@NgModule({
  imports: [RouterModule.forChild(routes), ToastrModule.forRoot()],
  exports: [RouterModule]
})
export class UserRoutingModule { }