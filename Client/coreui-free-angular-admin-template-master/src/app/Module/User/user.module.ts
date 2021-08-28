// Angular
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { NgModule } from '@angular/core';

import { AddUserComponent } from './add-user/add-user.component';
import { UserRoutingModule } from './user-routing.module';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { TabsModule } from 'ngx-bootstrap/tabs';
import { CarouselModule } from 'ngx-bootstrap/carousel';
import { CollapseModule } from 'ngx-bootstrap/collapse';
import { PaginationModule } from 'ngx-bootstrap/pagination';
import { PopoverModule } from 'ngx-bootstrap/popover';
import { ProgressbarModule } from 'ngx-bootstrap/progressbar';
import { TooltipModule } from 'ngx-bootstrap/tooltip';
import { AllUserListComponent } from './all-user-list/all-user-list.component';
import { ModeratorListComponent } from './moderator-list/moderator-list.component';
import { DeliverymanListComponent } from './deliveryman-list/deliveryman-list.component';
import { CustomerlisComponent } from './customerlis/customerlis.component';
import { UpdateUserComponent } from './update-user/update-user.component';
import { DeleteUserComponent } from './delete-user/delete-user.component';



@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    UserRoutingModule,
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
    AddUserComponent,
    AllUserListComponent,
    ModeratorListComponent,
    DeliverymanListComponent,
    CustomerlisComponent,
    UpdateUserComponent,
    DeleteUserComponent
  ]
})
export class UserModule { }