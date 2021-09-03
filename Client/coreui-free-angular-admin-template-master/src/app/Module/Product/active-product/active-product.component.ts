import { Component, OnInit } from '@angular/core';
import { Product } from '../../../Model/Product';
import { ProductService } from '../../../Services/Product/product.service';

@Component({
  selector: 'app-active-product',
  templateUrl: './active-product.component.html',
  styleUrls: ['./active-product.component.scss']
})
export class ActiveProductComponent implements OnInit {
  public lstproduct:Product[]=new Array<Product>();

  constructor(private service:ProductService) { }

  ngOnInit(): void {
    this.service.ActiveProduct().subscribe((res:any)=>{
      this.lstproduct=res;
    })
  }

}
