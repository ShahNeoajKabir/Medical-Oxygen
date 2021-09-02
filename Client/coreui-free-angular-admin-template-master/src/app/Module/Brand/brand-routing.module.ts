

import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ToastrModule } from 'ngx-toastr';
import { ActiveBrandComponent } from './active-brand/active-brand.component';
import { AddBrandComponent } from './add-brand/add-brand.component';
import { DeactiveBrandComponent } from './deactive-brand/deactive-brand.component';
import { DeleteBrandComponent } from './delete-brand/delete-brand.component';
import { UpdateBrandComponent } from './update-brand/update-brand.component';


const routes: Routes = [
    { 
        path: '',
    data: {
      title: 'Brand'
    },
    children: [
      {
        path: '',
        redirectTo: 'ActiveBrand'
      },
      {
        path: 'AddBrand',
        component: AddBrandComponent,
        data: {
          title: 'AddBrand'
        }
      },
      {
        path: 'ActiveBrand',
        component: ActiveBrandComponent,
        data: {
          title: 'ActiveBrand'
        }
      },
      {
          path:'DeactiveBrand',
          component:DeactiveBrandComponent,
          data:{
              title:'DeactiveBrand',
          }
      },

        {
            path:':id/edit',
            component:UpdateBrandComponent,
            data:{
                title:':id/edit',
            }
        },
        {
            path:':id/delete',
            component:DeleteBrandComponent,
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
export class BrandRoutingModule { }