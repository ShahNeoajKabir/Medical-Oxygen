// Angular
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { NgModule } from '@angular/core';
import { CustomerRoutingModule } from './customer-routing.module';
import { CustomerProductComponent } from './customer-product/customer-product.component';
import { ProductDetailsComponent } from './product-details/product-details.component';



@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    CustomerRoutingModule
  ],
  declarations: [
  
  
    CustomerProductComponent,
           ProductDetailsComponent
  ]
})
export class CustomerModule { }