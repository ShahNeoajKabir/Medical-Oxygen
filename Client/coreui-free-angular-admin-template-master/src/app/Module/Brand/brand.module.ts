// Angular
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { NgModule } from '@angular/core';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { TabsModule } from 'ngx-bootstrap/tabs';
import { CarouselModule } from 'ngx-bootstrap/carousel';
import { CollapseModule } from 'ngx-bootstrap/collapse';
import { PaginationModule } from 'ngx-bootstrap/pagination';
import { PopoverModule } from 'ngx-bootstrap/popover';
import { ProgressbarModule } from 'ngx-bootstrap/progressbar';
import { TooltipModule } from 'ngx-bootstrap/tooltip';
import { BrandRoutingModule } from './brand-routing.module';
import { AddBrandComponent } from './add-brand/add-brand.component';
import { ActiveBrandComponent } from './active-brand/active-brand.component';
import { DeactiveBrandComponent } from './deactive-brand/deactive-brand.component';
import { UpdateBrandComponent } from './update-brand/update-brand.component';
import { DeleteBrandComponent } from './delete-brand/delete-brand.component';



@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    BrandRoutingModule,
    BsDropdownModule.forRoot(),
    TabsModule,
    CarouselModule.forRoot(),
    CollapseModule.forRoot(),
    PaginationModule.forRoot(),
    PopoverModule.forRoot(),
    ProgressbarModule.forRoot(),
    TooltipModule.forRoot()
  ],
  declarations: [
  
    AddBrandComponent,
       ActiveBrandComponent,
       DeactiveBrandComponent,
       UpdateBrandComponent,
       DeleteBrandComponent
  ]
})
export class BrandModule { }