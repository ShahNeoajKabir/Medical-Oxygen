

import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ToastrModule } from 'ngx-toastr';
import { AboutUsComponent } from '../about-us/about-us.component';
import { CustomerProductComponent } from './customer-product/customer-product.component';
import { ProductDetailsComponent } from './product-details/product-details.component';


const routes: Routes = [
    { 
        path: '',
    data: {
      title: 'Home'
    },
    children: [
      {
        path: '',
        redirectTo: 'Home'
      },
      {
        path: 'Home',
        component: CustomerProductComponent,
        data: {
          title: 'Home'
        }
      },
        {
            path:':id/ProductDetails',
            component:ProductDetailsComponent,
            data:{
                title:'ProductDetails',
            }
        },

        {
          path:'AboutUs',
          component:AboutUsComponent,
          data:{
              title:'AboutUs',
          }
      },
    ]
}



];

@NgModule({
  imports: [RouterModule.forChild(routes), ToastrModule.forRoot()],
  exports: [RouterModule]
})
export class CustomerRoutingModule { }