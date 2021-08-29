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
import { RoleRoutingModule } from './role-routing.module';
import { DeactiveRoleListComponent } from './deactive-role-list/deactive-role-list.component';
import { ActiveRoleListComponent } from './active-role-list/active-role-list.component';
import { AddRoleComponent } from './add-role/add-role.component';
import { UpdateRoleComponent } from './update-role/update-role.component';
import { DeleteRoleComponent } from './delete-role/delete-role.component';



@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    RoleRoutingModule,
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
  DeactiveRoleListComponent,
  ActiveRoleListComponent,
  AddRoleComponent,
  UpdateRoleComponent,
  DeleteRoleComponent
  ]
})
export class RoleModule { }