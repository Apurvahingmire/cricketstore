import { Component, OnInit } from '@angular/core';
import { brand } from '../../view/product/models/brand.model';
import { BrandService } from '../../view/product/services/brand.service';

@Component({
  selector: 'app-brandnew',
  templateUrl: './brandnew.component.html',
  styleUrls: ['./brandnew.component.css']
})
export class BrandnewComponent implements OnInit {
  brands?: brand[];
  constructor(private brandServices: BrandService){}
  ngOnInit(): void {
    this.brandServices.getAllBrands()
    .subscribe({
      next: (response) =>{
        this.brands = response;
      }
    })
  }

}
