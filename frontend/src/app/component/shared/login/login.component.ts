import { Router } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { LoginService } from '../../view/product/services/login.service';

 
@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
  email: string = "";
  passwordHash: string = "";
  // isLoggedIn: boolean = false;
 
  constructor(
    private router: Router,
    private toastr: ToastrService,
    private loginService: LoginService
  ) {}
 
  handleSubmit(event: Event): void {
    event.preventDefault();

    if (this.loginService.isLoggedIn) {
      this.toastr.error("Logout first user");
      return;
    }
    if (!this.email && !this.passwordHash) return;
 
    this.loginService.login({email: this.email, passwordHash: this.passwordHash})
    .subscribe((res) =>{
      this.loginService.isLoggedIn = true;
      this.saveDataLocally(res);
      this.router.navigate(['/']);
    },
    (error) =>{
      this.toastr.error(error.message);
      alert("Invalid Username or Password!");
    });
   
  }
 
  saveDataLocally(data: any): void {
    const result = localStorage.getItem('loginInfo');
    if (result === null)
    localStorage.setItem("loginInfo", JSON.stringify(data));
  }
}