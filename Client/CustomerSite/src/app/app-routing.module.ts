import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AppComponent } from './app.component';

const routes: Routes = [
  {
    path: '',
    component:AppComponent ,
    data: {
      title: 'dashboard'
    },
    children: [
      {
        path: 'Home',
        loadChildren: () => import('./Module/Customer/customer.module').then(m => m.CustomerModule)
      },
    ]
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
