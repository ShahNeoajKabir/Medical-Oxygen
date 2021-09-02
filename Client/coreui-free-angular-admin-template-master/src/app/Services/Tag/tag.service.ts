import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class TagService {
  url="http://localhost:54667/api/Tag/";

  constructor(private httpclient:HttpClient) { }

  public AddTag(Tag:any){
    return this.httpclient.post(this.url+"AddTag",Tag);
  }

  public ActiveTag(){
    return this.httpclient.get(this.url+"ActiveTag");
  }

  public DeactiveTag(){
    return this.httpclient.get(this.url+"DeactiveTag");
  }

  public GetById(Tag:any){
    return this.httpclient.post(this.url+"GetById",Tag);
  }

  public UpdateTag(Tag:any){
    return this.httpclient.post(this.url+"UpdateTag",Tag);
  }

  public DeleteTag(Tag:any){
    return this.httpclient.post(this.url+"DeleteTag",Tag);
  }
}
