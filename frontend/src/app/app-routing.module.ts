import { NgModule } from '@angular/core';
import { RegisterComponent} from './component/shared/register/register.component';
import { RouterModule, Routes } from '@angular/router';
import { AboutUsComponent } from './component/shared/about-us/about-us.component';
import { LoginComponent } from './component/shared/login/login.component';
import { HomeComponent } from './component/shared/home/home.component';
import { ContactusComponent } from './component/shared/contactus/contactus.component';
import { BrandComponent } from './component/shared/brand/brand.component';
import { ProductlistComponent } from './component/view/product/productlist/productlist.component';
import { AddproductComponent } from './component/view/product/addproduct/addproduct.component';
import { BrandnewComponent } from './component/shared/brandnew/brandnew.component';
import { SgproductComponent } from './component/view/product/sgproduct/sgproduct.component';
import { CartComponent } from './component/shared/cart/cart.component';
import { AdminComponent } from './component/shared/admin/admin.component';
import { ProductListComponent } from './component/view/product/product-list/product-list.component';
import { EditProductComponent } from './component/view/product/edit-product/edit-product.component';
import { OrderplacedComponent } from './component/view/product/orderplaced/orderplaced.component';
import { AdminUserComponent } from './component/shared/admin-user/admin-user.component';


const routes: Routes = [
  {
    path: '',
    component:HomeComponent
  },
  {
    path: 'register',
    component:RegisterComponent
  },
  {
    path: 'aboutus',
    component:AboutUsComponent
  },
  {
    path: 'login',
    component:LoginComponent
  },
  {
    path: 'contactus',
    component:ContactusComponent
  },
  {
    path: 'brand',
    component:BrandComponent
  },
  
  {
  path: 'brand/products',
  component:ProductlistComponent
  },
  {
    path: 'admin/product-list/add',
    component:AddproductComponent
    },
   
    {
      path: 'brand/products/:brandId',
      component:SgproductComponent
    },
    {
      path: 'cart',
      component:CartComponent
    },
      {
        path: 'admin',
        component:AdminComponent
      },
      {
        path: 'admin/product-list',
        component:ProductListComponent
      },
      {
        path: 'admin/product-list/:id',
        component:EditProductComponent
      },
      {
        path: 'orderplaced',
        component:OrderplacedComponent
      },
      {
        path: 'admin/admin-users',
        component:AdminUserComponent
      }
    
    
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
