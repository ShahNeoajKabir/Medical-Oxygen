import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class RoleService {
  url="http://localhost:54667/api/Role/";

  constructor(private httpclient:HttpClient) { }

  public AddRole(Role:any){
    return this.httpclient.post(this.url+"AddRole",Role);
  }

  public DeactivateRole(){
    return this.httpclient.get(this.url+"DeactivateRole");
  }

  public ActiveRole(){
    return this.httpclient.get(this.url+"ActivateRole");
  }

  public GetById(Role:any){
    return this.httpclient.post(this.url+"GetById",Role);
  }

  public UpdateRole(Role:any){
    return this.httpclient.post(this.url+"UpdateRole",Role);
  }

  public DeleteRole(Role:any){
    return this.httpclient.post(this.url+"DeleteRole",Role);
  }


}
