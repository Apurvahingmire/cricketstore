import { Component, OnDestroy } from '@angular/core';
import { Router } from '@angular/router';
import { Subscription } from 'rxjs/internal/Subscription';
import { AddProductRequest } from '../models/addproduct-request-model';
import { ProductService } from '../services/product.service';

@Component({
  selector: 'app-addproduct',
  templateUrl: './addproduct.component.html',
  styleUrls: ['./addproduct.component.css']
})
export class AddproductComponent implements OnDestroy {
model: AddProductRequest;
private addProductSubscription?: Subscription;

constructor(private productService: ProductService,
  private router: Router) {
  this.model = {
    name: '',
    price: '',
    description: '',
    stockAvailable: '',
    brandId: '',
    imageUrl: '',
  };
}
  

  onFormSubmit(){
    this.addProductSubscription= this.productService.addProduct(this.model)
    .subscribe({
      next: (response) =>{
   this.router.navigateByUrl('/admin/product-list');
      } 
    })
    
  }
  ngOnDestroy(): void {
    this.addProductSubscription?.unsubscribe()
  }

}