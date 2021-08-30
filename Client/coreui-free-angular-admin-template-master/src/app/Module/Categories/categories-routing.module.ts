

import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ToastrModule } from 'ngx-toastr';
import { ActiveCategoriesComponent } from './active-categories/active-categories.component';
import { AddCategoriesComponent } from './add-categories/add-categories.component';
import { DeactiveCategoriesComponent } from './deactive-categories/deactive-categories.component';
import { DeleteCategoriesComponent } from './delete-categories/delete-categories.component';
import { UpdateCategoriesComponent } from './update-categories/update-categories.component';


const routes: Routes = [
    { 
        path: '',
    data: {
      title: 'Categories'
    },
    children: [
      {
        path: '',
        redirectTo: 'ActiveCategories'
      },
      {
        path: 'AddCategories',
        component: AddCategoriesComponent,
        data: {
          title: 'AddCategories'
        }
      },
      {
        path: 'ActiveCategories',
        component: ActiveCategoriesComponent,
        data: {
          title: 'ActiveCategories'
        }
      },
      {
          path:'DeactiveCategories',
          component:DeactiveCategoriesComponent,
          data:{
              title:'DeactiveCategories',
          }
      },

        {
            path:':id/edit',
            component:UpdateCategoriesComponent,
            data:{
                title:':id/edit',
            }
        },
        {
            path:':id/delete',
            component:DeleteCategoriesComponent,
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
export class CategoriesRoutingModule { }