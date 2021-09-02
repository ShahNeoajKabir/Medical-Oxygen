

import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ToastrModule } from 'ngx-toastr';
import { ActiveAttributeComponent } from './active-attribute/active-attribute.component';
import { AddAttributeComponent } from './add-attribute/add-attribute.component';
import { DeactiveAttributeComponent } from './deactive-attribute/deactive-attribute.component';
import { DeleteAttributeComponent } from './delete-attribute/delete-attribute.component';
import { UpdateAttributeComponent } from './update-attribute/update-attribute.component';


const routes: Routes = [
    { 
        path: '',
    data: {
      title: 'Attribute'
    },
    children: [
      {
        path: '',
        redirectTo: 'ActiveAttribute'
      },
      {
        path: 'AddAttribute',
        component: AddAttributeComponent,
        data: {
          title: 'AddAttribute'
        }
      },
      {
        path: 'ActiveAttribute',
        component: ActiveAttributeComponent,
        data: {
          title: 'ActiveAttribute'
        }
      },
      {
          path:'DeactiveAttribute',
          component:DeactiveAttributeComponent,
          data:{
              title:'DeactiveAttribute',
          }
      },

        {
            path:':id/edit',
            component:UpdateAttributeComponent,
            data:{
                title:':id/edit',
            }
        },
        {
            path:':id/delete',
            component:DeleteAttributeComponent,
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
export class AttributeRoutingModule { }