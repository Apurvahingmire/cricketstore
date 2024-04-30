import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Register } from '../../models/register.model';
import { User } from '../../models/user.model';

@Injectable({
  providedIn: 'root'
})
export class RegisterService {

  constructor(private http: HttpClient ) { }

  registerUser(model : Register): Observable<void> {
    return this.http.post<void>(`${environment.apiBaseUrl}/api/Users`,model);
  }
 
  getAllUser(): Observable<User[]> {
    return this.http.get<User[]>(`${environment.apiBaseUrl}/api/Users`);
  }
 
}

