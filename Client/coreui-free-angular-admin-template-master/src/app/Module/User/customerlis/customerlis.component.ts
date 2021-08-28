import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { User } from '../../../Model/User';
import { UserService } from '../../../Services/User/user.service';

@Component({
  selector: 'app-customerlis',
  templateUrl: './customerlis.component.html',
  styleUrls: ['./customerlis.component.scss']
})
export class CustomerlisComponent implements OnInit {
  public lstuser:User[]=new Array<User>();

  constructor( private userservice:UserService,private router:Router) { }

  ngOnInit(): void {
    this.userservice.GetAllCustomer().subscribe((res:any)=>{
      this.lstuser=res;
      console.log(res);
    });
  }

}
