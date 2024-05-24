import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { ReactiveFormsModule } from '@angular/forms';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { DashboardComponent } from './pages/dashboard/dashboard.component';
import { NewSaleComponent } from './pages/new-sale/new-sale.component';
import { SaleListComponent } from './pages/sale-list/sale-list.component';
import { NewPurchaseComponent } from './pages/new-purchase/new-purchase.component';
import { PurchaseListComponent } from './pages/purchase-list/purchase-list.component';
import { StockComponent } from './pages/stock/stock.component';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { RegisterComponent } from './pages/register/register.component';
import { LoginComponent } from './pages/login/login.component';
import { AuthService } from './services/auth.service';
import { NewProductComponent } from './pages/new-product/new-product.component';
import { ProductListComponent } from './pages/product-list/product-list.component';


@NgModule({
  declarations: [
    AppComponent,
    DashboardComponent,
    NewSaleComponent,
    SaleListComponent,
    NewPurchaseComponent,
    PurchaseListComponent,
    StockComponent,
    RegisterComponent,
    LoginComponent,
    NewProductComponent,
    ProductListComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule
  ],
  providers: [AuthService],
  bootstrap: [AppComponent]
})
export class AppModule { }
