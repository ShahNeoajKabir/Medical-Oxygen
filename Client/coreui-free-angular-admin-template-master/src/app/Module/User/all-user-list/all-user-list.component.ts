import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { User, VmUsers } from '../../../Model/User';
import { UserService } from '../../../Services/User/user.service';

@Component({
  selector: 'app-all-user-list',
  templateUrl: './all-user-list.component.html',
  styleUrls: ['./all-user-list.component.scss']
})
export class AllUserListComponent implements OnInit {
  public lstUser:VmUsers[]= new Array<VmUsers>();
  // public lstuser:User[]= new Array<User>();

  public searchuser:string="";


  constructor(private userservice:UserService, private router:Router) { }

  ngOnInit(): void {
    this.userservice.GetAll().subscribe((res:any)=>{
      this.lstUser=res;
      console.log(res);
    });
    // this.userservice.GetAllMeterReader().subscribe((res:any)=>{
    //   this.lstuser=res;
    //   console.log(this.lstuser);
    // })
  }
  Edit(id: any) {

    console.log(id);
  }



}
