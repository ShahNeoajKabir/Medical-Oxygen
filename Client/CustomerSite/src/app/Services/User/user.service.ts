import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class UserService {
url="http://localhost:54667/api/User/";
  constructor(private httpclient:HttpClient) { }

  public Registration(User:any){
    return this.httpclient.post(this.url+"Registration",User);
  }
}
