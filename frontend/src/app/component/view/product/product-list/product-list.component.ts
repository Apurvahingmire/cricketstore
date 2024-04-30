import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { product } from '../models/product.model';
import { ProductService } from '../services/product.service';

@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.css']
})
export class ProductListComponent implements OnInit {

  products$?: Observable<product[]>;
  
constructor (private productService: ProductService){
  
}
  ngOnInit(): void {
    this.products$ = this.productService.getAllProducts();
   
  }
}
