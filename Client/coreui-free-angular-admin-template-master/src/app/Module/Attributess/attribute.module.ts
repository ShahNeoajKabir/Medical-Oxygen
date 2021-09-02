import { CommonModule } from "@angular/common";
import { NgModule } from "@angular/core";
import { FormsModule } from "@angular/forms";
import { CarouselModule } from "ngx-bootstrap/carousel";
import { CollapseModule } from "ngx-bootstrap/collapse";
import { BsDropdownModule } from "ngx-bootstrap/dropdown";
import { PaginationModule } from "ngx-bootstrap/pagination";
import { PopoverModule } from "ngx-bootstrap/popover";
import { ProgressbarModule } from "ngx-bootstrap/progressbar";
import { TabsModule } from "ngx-bootstrap/tabs";
import { TooltipModule } from "ngx-bootstrap/tooltip";
import { AttributeRoutingModule } from "./attribute-routing.module";
import { AddAttributeComponent } from './add-attribute/add-attribute.component';
import { ActiveAttributeComponent } from './active-attribute/active-attribute.component';
import { DeactiveAttributeComponent } from './deactive-attribute/deactive-attribute.component';
import { UpdateAttributeComponent } from './update-attribute/update-attribute.component';
import { DeleteAttributeComponent } from './delete-attribute/delete-attribute.component';

@NgModule({
    imports: [
      CommonModule,
      FormsModule,
      AttributeRoutingModule,
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
    
    AddAttributeComponent,
         ActiveAttributeComponent,
         DeactiveAttributeComponent,
         UpdateAttributeComponent,
         DeleteAttributeComponent
  ]
  })
  export class AttributeModule { }