import { CommonModule, HashLocationStrategy, LocationStrategy } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { ToastrModule } from 'ngx-toastr';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { AuthService } from './Common/Auth/auth.service';
import { httpInterceptorProviders } from './Common/interceptor';
import { AboutUsComponent } from './Module/about-us/about-us.component';

@NgModule({
  declarations: [
    AppComponent,
    AboutUsComponent,
    
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule,
    CommonModule,
    ToastrModule.forRoot()
  ],
  providers: [HttpClientModule,httpInterceptorProviders,
    {
      provide: LocationStrategy,
      useClass: HashLocationStrategy
    },
    AuthService
  ],
  bootstrap: [ AppComponent ]
})
export class AppModule { }
