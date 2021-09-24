import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class AttributesService {
  url="http://localhost:54667/api/Attribute/";

  constructor(private httpclient:HttpClient) { }

  public AddAttribute(Attributes:any){
    return this.httpclient.post(this.url+"AddAttribute",Attributes);
  }

  public ActiveAttribute(){
    return this.httpclient.get(this.url+"ActiveAttribute");
  }


  public DeactiveAttribute(){
    return this.httpclient.get(this.url+"DeactiveAttribute");
  }

  public GetById(Attribute:any){
    return this.httpclient.post(this.url+"GetById",Attribute);
  }

  public UpdateAttribute(Attribute:any){
    return this.httpclient.post(this.url+"UpdateAttribute",Attribute);
  }


  public DeleteAttribute(Attribute:any){
    return this.httpclient.post(this.url+"DeleteAttribute",Attribute);
  }
}
