import { Component, OnDestroy, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Subscription } from 'rxjs/internal/Subscription';
import { product } from '../models/product.model';
import { updateProductRequest } from '../models/updateproduct-request-model';
import { ProductService } from '../services/product.service';

@Component({
  selector: 'app-edit-product',
  templateUrl: './edit-product.component.html',
  styleUrls: ['./edit-product.component.css']
})
export class EditProductComponent implements OnInit, OnDestroy {

  id: number | null = null;
  paramsSubsricption?: Subscription;
  product?: product ;
  editProductSubscription?: Subscription;

  constructor(private route: ActivatedRoute, private productService: ProductService, private router: Router ){
    
  }
  
  ngOnInit(): void{
this.paramsSubsricption = this.route.paramMap.subscribe({
  next: (resp) => {
    this.id = (Number)(resp.get('id'));

   if(this.id){
this.productService.getProductByID(this.id)
.subscribe({
  next: (resp)=>{
    this.product = resp;
  },
  error: (resp)=>{
    console.log(resp);
  }

})
   }
  }
});
  }
  onFormSubmit(id: number): void{
    var updateProductRequest: updateProductRequest ={
      id: this.product?.id ?? 0,
      name: this.product?.name ?? '',
      price: this.product?.price ?? 0,
      description: this.product?.description ?? '',
      stockAvailable: this.product?.stockAvailable ?? 0,
      imageUrl: this.product?.imageUrl ?? '',
      brandId:this.product?.brandId ?? 0,
    };
    if(this.id){
   this.editProductSubscription = this.productService.updateProduct(this.id, updateProductRequest)
.subscribe({
  next:(response) =>{
    this.router.navigateByUrl('/admin/product-list');
  }
})
    
    }
  }
  ngOnDestroy(): void {
    this.paramsSubsricption?.unsubscribe();
    this.editProductSubscription?.unsubscribe();

  }
  onDelete(id: number): void {
    if(this.id){
    this.productService.deleteProduct(this.id)
   .subscribe({
    next:() => {
      this.router.navigateByUrl('/admin/product-list');
    }
   }) 
  }

  }
}
