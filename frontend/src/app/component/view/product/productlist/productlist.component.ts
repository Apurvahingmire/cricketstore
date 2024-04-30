import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { product } from '../models/product.model';
import { ProductService } from '../services/product.service';

@Component({
  selector: 'app-productlist',
  templateUrl: './productlist.component.html',
  styleUrls: ['./productlist.component.css']
})
export class ProductlistComponent implements OnInit {
  products: product[] = [];
  productToSave = {
    id: 0,
    name: '',
    price: 0,
    stockAvailable: 0,
    imageUrl: '',
    quantity: 0
  };

  constructor(private productService: ProductService) {

  }
  ngOnInit(): void {
    this.productService.getAllProducts()
      .subscribe({
        next: (response) => {
          this.products = response;
        }
      });

  }
  onAddToCart(id: number) {
    for (let i = 0; i < this.products?.length; i++) {
      const product = this.products[i];
      if (product.id === id) {
        this.productToSave = {
          id: product.id,
          name: product.name,
          price: product.price,
          stockAvailable: product.stockAvailable,
          imageUrl: product.imageUrl,
          quantity: 1
        };
      }
      if(this.productToSave.id){
        let key: string = `order_${this.productToSave.id}}`;
        localStorage.setItem(key, JSON.stringify(this.productToSave));
      }
    }
  }
}
