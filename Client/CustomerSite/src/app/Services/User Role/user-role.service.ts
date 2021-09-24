import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class UserRoleService {
  url="http://localhost:54667/api/UserRole/";
  constructor(private httpclient:HttpClient) { }

  public AddUserRole(UserRole:any){
    return this.httpclient.post(this.url+"AddUserRole",UserRole);
  }

  public ActiveUserRole(){
    return this.httpclient.get(this.url+"ActiveUserRole");
  }
  public DeactiveUserRole(){
    return this.httpclient.get(this.url+"DeactiveUserRole");
  }

  public UpdateUserRole(UserRole:any){
    return this.httpclient.post(this.url+"UpdateUserRole",UserRole);
  }

  public DeleteUserRole(UserRole:any){
    return this.httpclient.post(this.url+"DeleteUserRole",UserRole);
  }

  public GetById(UserRole:any){
    return this.httpclient.post(this.url+"GetById",UserRole);
  }
}
