import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HeaderComponent } from './component/shared/header/header.component';
import { FooterComponent } from './component/shared/footer/footer.component';
import { RegisterComponent } from './component/shared/register/register.component';
import { AboutUsComponent } from './component/shared/about-us/about-us.component';
import { LoginComponent } from './component/shared/login/login.component';
import { HomeComponent } from './component/shared/home/home.component';
import { ContactusComponent } from './component/shared/contactus/contactus.component';
import { BrandComponent } from './component/shared/brand/brand.component';
import { ProductlistComponent } from './component/view/product/productlist/productlist.component';
import { AddproductComponent } from './component/view/product/addproduct/addproduct.component';
import { FormsModule } from '@angular/forms';
import {HttpClientModule} from '@angular/common/http';
import { BrandnewComponent } from './component/shared/brandnew/brandnew.component';
import { SsproductComponent } from './component/view/product/ssproduct/ssproduct.component';
import { SgproductComponent } from './component/view/product/sgproduct/sgproduct.component';
import { CartComponent } from './component/shared/cart/cart.component';
import{ToastrModule} from 'ngx-toastr';
import { AdminComponent } from './component/shared/admin/admin.component';
import { ProductListComponent } from './component/view/product/product-list/product-list.component';
import { EditProductComponent } from './component/view/product/edit-product/edit-product.component';
import { OrderplacedComponent } from './component/view/product/orderplaced/orderplaced.component';
import { AdminUserComponent } from './component/shared/admin-user/admin-user.component';

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    FooterComponent,
    RegisterComponent,
    AboutUsComponent,
    LoginComponent,
    HomeComponent,
    ContactusComponent,
    BrandComponent,
    ProductlistComponent,
    AddproductComponent,
    BrandnewComponent,
    SsproductComponent,
    SgproductComponent,
    CartComponent,
    AdminComponent,
    ProductListComponent,
    EditProductComponent,
    OrderplacedComponent,
    AdminUserComponent,
  
  


  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule,
    ToastrModule.forRoot(),
  

  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
