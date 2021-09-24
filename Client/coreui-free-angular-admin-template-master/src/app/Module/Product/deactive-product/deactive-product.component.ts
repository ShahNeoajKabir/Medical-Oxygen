import { Component, OnInit } from '@angular/core';
import { Product } from '../../../Model/Product';
import { ProductService } from '../../../Services/Product/product.service';

@Component({
  selector: 'app-deactive-product',
  templateUrl: './deactive-product.component.html',
  styleUrls: ['./deactive-product.component.scss']
})
export class DeactiveProductComponent implements OnInit {
  public lstproduct:Product[]=new Array<Product>();

  constructor(private service:ProductService) { }

  ngOnInit(): void {
    this.service.DeactiveProduct().subscribe((res:any)=>{
      this.lstproduct=res;
    })
  }

}
