import { Component } from '@angular/core';
import { User } from '../../view/product/models/user.model';
import { AdminUserService } from '../../view/product/services/admin-user.service';

@Component({
  selector: 'app-admin-user',
  templateUrl: './admin-user.component.html',
  styleUrls: ['./admin-user.component.css']
})
export class AdminUserComponent {
  allusers?: User[];
   
 
  constructor(private adminUserService: AdminUserService) {}
 
 
  ngOnInit() : void {
    this.getUserList();
}
 
  getUserList(): void {
    this.adminUserService.getAllUsers()
    .subscribe({
      next: (resp)=>{
        this.allusers = resp;
        console.log(resp);
      },
      error: (resp)=>{
        console.log(resp);
      }
    });
  }
}

