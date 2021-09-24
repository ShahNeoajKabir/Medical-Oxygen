import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Product } from 'src/app/Model/Product';
import { ProductService } from 'src/app/Services/Product/product.service';

@Component({
  selector: 'app-customer-product',
  templateUrl: './customer-product.component.html',
  styleUrls: ['./customer-product.component.css']
})
export class CustomerProductComponent implements OnInit {

  public lstproduct:Product[]=new Array<Product>();
  

  constructor(private router:Router, private productservice:ProductService) { }

  ngOnInit(): void {
    this.productservice.ActiveProduct().subscribe((res:any)=>{
      this.lstproduct=res;
    })
  }
}
