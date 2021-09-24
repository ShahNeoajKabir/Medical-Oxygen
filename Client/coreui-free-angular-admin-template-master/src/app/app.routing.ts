import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AuthGuard } from './Common/Auth/auth.guard';

// Import Containers
import { DefaultLayoutComponent } from './containers';

import { P404Component } from './views/error/404.component';

export const routes: Routes = [
  {
    path: '',
    redirectTo: 'dashboard',
    pathMatch: 'full',
  },
  // { path: '', loadChildren: () => import('../app/Components/signin.module').then(m => m.SigninModule) },
  { path: '', loadChildren: () => import('../app/Components/signin.module').then(m => m.SigninModule) },
  {
    path: '',
    component: DefaultLayoutComponent,
    data: {
      title: 'Home'
    },
    children: [
      {
        path: 'base',
        loadChildren: () => import('./views/base/base.module').then(m => m.BaseModule)
      },
      {
        path:'User',
        loadChildren:()=>import('./Module/User/user.module').then(m=>m.UserModule)

      },
      {
        path:'Role',
        loadChildren:()=>import('./Module/Role/role.module').then(m=>m.RoleModule)

      },
      {
        path:'UserRole',
        loadChildren:()=>import('./Module/UserRole/userrole.module').then(m=>m.UserRoleModule)

      },
      {
        path:'Categories',
        loadChildren:()=>import('./Module/Categories/categories.module').then(m=>m.CategoriesModule)

      },
      {
        path:'Brand',
        loadChildren:()=>import('./Module/Brand/brand.module').then(m=>m.BrandModule)

      },
      {
        path:'Attribute',
        loadChildren:()=>import('./Module/Attributess/attribute.module').then(m=>m.AttributeModule)

      },
      {
        path:'Product',
        loadChildren:()=>import('./Module/Product/product.module').then(m=>m.ProductModule)

      },

      
      {
        path: 'dashboard',
        loadChildren: () => import('./views/dashboard/dashboard.module').then(m => m.DashboardModule)
      },

    ]
  },
  { path: '**', component: P404Component }
];

@NgModule({
  imports: [ RouterModule.forRoot(routes, { relativeLinkResolution: 'legacy' }) ],
  exports: [ RouterModule ]
})
export class AppRoutingModule {}
