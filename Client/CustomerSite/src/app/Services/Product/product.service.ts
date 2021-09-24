import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class ProductService {
  url="http://localhost:54667/api/Product/";

  constructor(private httpclient:HttpClient) { }

  public AddProduct(Product:any){
    return this.httpclient.post(this.url+"AddProduct",Product);
  }

  public ActiveProduct(){
    return this.httpclient.get(this.url+"ActiveProduct");
  }
  public DeactiveProduct(){
    return this.httpclient.get(this.url+"DeactiveProduct");
  }
  public GetById(Product:any){
    return this.httpclient.post(this.url+"GetById",Product);
  }
  public ProductDetails(){
    return this.httpclient.get(this.url+"ProductDetails");
  }
}
