import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { VMLogin } from '../Common/VMLogin';

@Injectable({
  providedIn: 'root'
})
export class SecurityService {

  url="http://localhost:54667/api/Security/";

  constructor(private httpclient:HttpClient) { }

  public Login(obj:VMLogin)
  {
    return this.httpclient.post(this.url+'Login',obj);

  }

  public Registration(User:any)
  {
    return this.httpclient.post(this.url+'Registration',User);

  }
}
