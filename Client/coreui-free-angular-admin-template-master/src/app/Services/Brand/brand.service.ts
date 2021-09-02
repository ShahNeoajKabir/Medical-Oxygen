import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class BrandService {
  url="http://localhost:54667/api/Brand/";

  constructor(private httpclient:HttpClient) { }

  public AddBrand(Brand:any){
    return this.httpclient.post(this.url+"AddBrand",Brand);
  }

  public ActiveBrand(){
    return this.httpclient.get(this.url+"ActiveBrand");
  }

  public DeactiveBrand(){
    return this.httpclient.get(this.url+"DeactiveBrand");
  }

  public GetById(Brand:any){
    return this.httpclient.post(this.url+"GetById",Brand);
  }

  public UpdateBrand(Brand:any){
    return this.httpclient.post(this.url+"UpdateBrand",Brand);
  }

  public DeleteBrand(Brand:any){
    return this.httpclient.post(this.url+"DeleteBrand",Brand);
  }
}
