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
import { CategoriesRoutingModule } from './categories-routing.module';
import { ActiveCategoriesComponent } from './active-categories/active-categories.component';
import { DeactiveCategoriesComponent } from './deactive-categories/deactive-categories.component';
import { AddCategoriesComponent } from './add-categories/add-categories.component';
import { UpdateCategoriesComponent } from './update-categories/update-categories.component';
import { DeleteCategoriesComponent } from './delete-categories/delete-categories.component';



@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    CategoriesRoutingModule,
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
 ActiveCategoriesComponent,
 DeactiveCategoriesComponent,
 AddCategoriesComponent,
 UpdateCategoriesComponent,
 DeleteCategoriesComponent
  ]
})
export class CategoriesModule { }