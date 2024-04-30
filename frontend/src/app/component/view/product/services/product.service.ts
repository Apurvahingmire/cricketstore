import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { AddProductRequest } from '../models/addproduct-request-model';
import { product } from '../models/product.model';
import { updateProductRequest } from '../models/updateproduct-request-model';

@Injectable({
  providedIn: 'root'
})
export class ProductService {

  constructor(private http: HttpClient) { }

  addProduct(model: AddProductRequest): Observable<void>{
return this.http.post<void>(`${environment.apiBaseUrl}/api/products`, model);
  }
  getAllProducts(): Observable<product[]>{
return this.http.get<product[]>(`${environment.apiBaseUrl}/api/products`);
  }
  getByBrandId(brandId:number): Observable<product[]>{
    return this.http.get<product[]>(`${environment.apiBaseUrl}/api/products/getbyBrandId/${brandId}`);
      }
       deleteProduct(id: number) : Observable<product>{
         return this.http.delete<product>(`${environment.apiBaseUrl}/api/products/${id}`);
       }
       getProductByID(id: number): Observable<product>{
        return this.http.get<product>(`${environment.apiBaseUrl}/api/products/${id}`);
      }
      updateProduct(id: number, updateProductRequest: updateProductRequest) :Observable<product>{
        return this.http.put<product>(`${environment.apiBaseUrl}/api/products/${id}` ,
        updateProductRequest);
      }

}
