import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { User, VmUsers } from '../../../Model/User';
import { UserService } from '../../../Services/User/user.service';

@Component({
  selector: 'app-deliveryman-list',
  templateUrl: './deliveryman-list.component.html',
  styleUrls: ['./deliveryman-list.component.scss']
})
export class DeliverymanListComponent implements OnInit {
  public lstUser:VmUsers[]= new Array<VmUsers>();
  // public lstuser:User[]= new Array<User>();

  public searchuser:string="";


  constructor(private userservice:UserService, private router:Router) { }

  ngOnInit(): void {
    this.userservice.GetDeliveryMan().subscribe((res:any)=>{
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
