import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Status } from '../../../Common/Enum';
import { Utility } from '../../../Common/Utility';
import { Brand } from '../../../Model/Brand';
import { BrandService } from '../../../Services/Brand/brand.service';
import { NotificationService } from '../../../Services/Notification/notification.service';

@Component({
  selector: 'app-add-brand',
  templateUrl: './add-brand.component.html',
  styleUrls: ['./add-brand.component.scss']
})
export class AddBrandComponent implements OnInit {
  public objbrand:Brand=new Brand();
  public lstStatus:any;

  constructor(private service:BrandService, private utility:Utility,private route:Router,private notification:NotificationService) { }

  ngOnInit(): void {
    this.lstStatus=this.utility.enumToArray(Status);
  }

  AddBrand(){
    this.service.AddBrand(this.objbrand).subscribe(res=>{
      this.notification.showSuccess("","");
      if(this.objbrand.Status==1){
        this.route.navigate(['/Brand/ActiveBrand']);
      }
      else{
        this.route.navigate(['/Brand/DeactiveBrand']);
      }

    },er=>{
      this.notification.showError("","");
      this.route.navigate(['/Brand/AddBrand']);

    })
  }




}
