import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from './Common/Auth/auth.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})

export class AppComponent implements OnInit {


  public roleId:any;
  constructor( private router:Router,public authservice: AuthService) { }

  ngOnInit(): void {
    this.roleId=this.authservice.getUserRole();
    console.log(this.roleId);
  }
}
