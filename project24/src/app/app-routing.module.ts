import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { NewPurchaseComponent } from './pages/new-purchase/new-purchase.component';
import { NewSaleComponent } from './pages/new-sale/new-sale.component';
import { PurchaseListComponent } from './pages/purchase-list/purchase-list.component';
import { SaleListComponent } from './pages/sale-list/sale-list.component';
import { StockComponent } from './pages/stock/stock.component';
import { DashboardComponent } from './pages/dashboard/dashboard.component';
import { LoginComponent } from './pages/login/login.component';
import { RegisterComponent } from './pages/register/register.component';
import { AppComponent } from './app.component';
import { ProductListComponent } from './pages/product-list/product-list.component';
import { NewProductComponent } from './pages/new-product/new-product.component';
import { AuthGuard } from './guards/auth.guard';


const routes: Routes = [
  {
    path:'',
    component:LoginComponent,
    pathMatch:'full'
  },
  {
    path:'app-component',
    component:AppComponent,
    canActivate:[AuthGuard]
  
  },
  {
    path:'new-product',
    component:NewProductComponent,
    canActivate:[AuthGuard]
  },
  {
    path:'product-list',
    component:ProductListComponent,
    canActivate:[AuthGuard]
  },
  {
    path:'new-Purchase',
    component:NewPurchaseComponent,
    canActivate:[AuthGuard]
  },
  {
    path:'new-Sale',
    component:NewSaleComponent,
    canActivate:[AuthGuard]
  },
  {
    path:'purchase-list',
    component:PurchaseListComponent,
    canActivate:[AuthGuard]
  },
  {
    path:'sale-list',
    component:SaleListComponent,
    canActivate:[AuthGuard]
  },
  {
    path:'stock',
    component:StockComponent,
    canActivate:[AuthGuard]
  },
  {
    path:'dashboard',
    component:DashboardComponent,
    canActivate:[AuthGuard]
  },
  {
    path:'login',
    component:LoginComponent
  },
  {
    path:'register',
    component:RegisterComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }


