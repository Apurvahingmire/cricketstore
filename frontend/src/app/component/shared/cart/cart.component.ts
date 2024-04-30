import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.css']
})
export class CartComponent implements OnInit{
  Cart: boolean = false;

  productList: any[] = [];
  // products: product;

  constructor(){}
  ngOnInit(): void {
    
    for(let i=0; i<localStorage.length; i++){
      const key = localStorage.key(i);

      if(key && key.includes('order_')){
        const value = localStorage.getItem(key);
        const parsedValue = value ? JSON.parse(value) : value;

        this.productList?.push(parsedValue);
        console.log(this.productList);
      }
    }
  }

  getTotalPrice(): number{
    let total = 0;

    this.productList.forEach(product => total += product.price * product.quantity);

    return total;
  }

  onAddProduct(id: number): void{
    for(let i=0; i<localStorage.length; i++){
      const key = localStorage.key(i);

      if(key && key.includes(`order_${id}`)){
        const value = localStorage.getItem(key);
        const parsedValue = value ? JSON.parse(value) : value;
        if(parsedValue.quantity < parsedValue.stockAvailable)
          parsedValue.quantity = parsedValue.quantity + 1;

        localStorage.setItem(key, JSON.stringify(parsedValue));
      }
    }
    for(let i=0; i<this.productList.length; i++){
      const product = this.productList[i];

      if(product.id === id){
        if(product.quantity < product.stockAvailable)
        product.quantity = product.quantity + 1;
      }
    }
  }

  onMinusProduct(id: number): void{
    for(let i=0; i<localStorage.length; i++){
      const key = localStorage.key(i);

      if(key && key.includes(`order_${id}`)){
        const value = localStorage.getItem(key);
        const parsedValue = value ? JSON.parse(value) : value;
        if(parsedValue.quantity > 1)
          parsedValue.quantity = parsedValue.quantity - 1;

        localStorage.setItem(key, JSON.stringify(parsedValue));
      }
    }
    for(let i=0; i<this.productList.length; i++){
      const product = this.productList[i];

      if(product.id === id){
        if(product.quantity > 1)
        product.quantity = product.quantity - 1;
      }
    }
  }

  onRemoveProduct(id: number): void{
    for(let i=0; i<localStorage.length; i++){
      const key = localStorage.key(i);

      if(key && key.includes(`order_${id}`)){
        localStorage.removeItem(key);
      }
    }
    for(let i=0; i<this.productList.length; i++){
      const product = this.productList[i];

      if(product.id === id){
        this.productList = this.productList.filter(b => b !== product);
      }
    }
  }

  onRemoveCart(): void{
    for(let i=0; i<localStorage.length; i++){
      const key = localStorage.key(i);

      if(key && key.includes(`order_`)){
        localStorage.removeItem(key);
      }
    }

    this.productList = [];
  }
}

