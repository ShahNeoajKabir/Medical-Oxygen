import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class UserService {
url="http://localhost:54667/api/User/";
  constructor(private httpclient:HttpClient) { }

  public AddUser(User:any){
    return this.httpclient.post(this.url+"AddUser",User);
  }
  public Registration(User:any){
    return this.httpclient.post(this.url+"Registration",User);
  }
  public GetAll(){
    return this.httpclient.post(this.url+"GetAll","");
  }
  public GetModerator(){
    return this.httpclient.post(this.url+"GetModerator","");
  }
  public GetDeliveryMan(){
    return this.httpclient.post(this.url+"GetDeliveryMan","");
  }
  public GetAllCustomer(){
    return this.httpclient.post(this.url+"GetAllCustomer","");
  }
  public GetById(User:any){
    return this.httpclient.post(this.url+"GetById",User);
  }

  public UpdateUser(User:any){
    return this.httpclient.post(this.url+"UpdateUser",User)
  }
  public DeleteUser(User:any){
    return this.httpclient.post(this.url+"DeleteUser",User)
  }
}
