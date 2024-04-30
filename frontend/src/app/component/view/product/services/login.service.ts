import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class LoginService {
  isLoggedIn:boolean = false;

  constructor(private http: HttpClient) { }
  login(data:any): Observable<any>{
    return this.http.post(`${environment.apiBaseUrl}/api/LogIn/login`, data)
  }
  
}
