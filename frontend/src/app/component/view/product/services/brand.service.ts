import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { brand } from '../models/brand.model';

@Injectable({
  providedIn: 'root'
})
export class BrandService {

  constructor(private http: HttpClient) { }
  getAllBrands(): Observable<brand[]>{
    return this.http.get<brand[]>(`${environment.apiBaseUrl}/api/brands`);
}
}