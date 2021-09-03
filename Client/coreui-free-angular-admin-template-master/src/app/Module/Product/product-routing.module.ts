

import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ToastrModule } from 'ngx-toastr';
import { ActiveProductComponent } from './active-product/active-product.component';
import { AddProductComponent } from './add-product/add-product.component';
import { DeactiveProductComponent } from './deactive-product/deactive-product.component';
import { DeleteProductComponent } from './delete-product/delete-product.component';
import { UpdateProductComponent } from './update-product/update-product.component';


const routes: Routes = [
    { 
        path: '',
    data: {
      title: 'Product'
    },
    children: [
      {
        path: '',
        redirectTo: 'ActiveProduct'
      },
      {
        path: 'AddProduct',
        component: AddProductComponent,
        data: {
          title: 'AddProduct'
        }
      },
      {
        path: 'ActiveProduct',
        component: ActiveProductComponent,
        data: {
          title: 'ActiveProduct'
        }
      },
      {
          path:'DeactiveProduct',
          component:DeactiveProductComponent,
          data:{
              title:'DeactiveProduct',
          }
      },

        {
            path:':id/edit',
            component:UpdateProductComponent,
            data:{
                title:':id/edit',
            }
        },
        {
            path:':id/delete',
            component:DeleteProductComponent,
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
export class ProductRoutingModule { }