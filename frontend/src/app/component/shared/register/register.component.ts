import { Component, OnDestroy } from '@angular/core';
import { Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { Register } from '../../view/product/models/register.model';
import { RegisterService } from '../../view/product/services/register/register.service';
 
@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnDestroy {
 
  model: Register;
  private registerServiceSubscription?:Subscription;
 
  constructor(private registerservice: RegisterService,private router: Router) {
    this.model ={
      firstname:'',
      lastName:'',
      username:'',
      email : '',
      passwordHash :'',
      gender : 1,
      dob : new Date(),
      phoneNo : 0,
      address:'',
      roleId : 1,
     
 
    }
  }
 
 
  onFormSubmit(){
  this.registerServiceSubscription = this.registerservice.registerUser(this.model)
  .subscribe({
    next: (response) => {
      this.router.navigateByUrl('/login');
    }
  })
}
 
  ngOnDestroy(): void {
    this.registerServiceSubscription?.unsubscribe();
  }
 
}