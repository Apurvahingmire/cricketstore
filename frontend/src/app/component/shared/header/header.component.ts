import { Component } from '@angular/core';
import { LoginService } from '../../view/product/services/login.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent {
  constructor(public loginService: LoginService){}
 
}

