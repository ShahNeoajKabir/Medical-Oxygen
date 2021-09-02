import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Status } from '../../../Common/Enum';
import { Utility } from '../../../Common/Utility';
import { Brand } from '../../../Model/Brand';
import { BrandService } from '../../../Services/Brand/brand.service';
import { NotificationService } from '../../../Services/Notification/notification.service';

@Component({
  selector: 'app-update-brand',
  templateUrl: './update-brand.component.html',
  styleUrls: ['./update-brand.component.scss']
})
export class UpdateBrandComponent implements OnInit {
  public objbrand:Brand=new Brand();
  public editbrand:Brand=new Brand();
  public lststatus:any;

  constructor(private service:BrandService, private utility:Utility , private route:Router, private activeroute:ActivatedRoute ,private notification:NotificationService) { }

  ngOnInit(): void {
    this.lststatus=this.utility.enumToArray(Status);

    if(this.activeroute.snapshot.params['id']!==undefined){
      this.editbrand.BrandId=this.activeroute.snapshot.params['id'];
      this.service.GetById(this.editbrand).subscribe((res:any)=>{
        this.objbrand=res;
      })

    }
  }

  UpdateBrand(){
    this.service.UpdateBrand(this.objbrand).subscribe(res=>{
      if(res){
        this.notification.showUpdate("","");
        if(this.objbrand.Status==1){
          this.route.navigate(['/Brand/ActiveBrand']);
        }
        else{
          this.route.navigate(['/Brand/DeactiveBrand']);
        }
      }

    },er=>{
      this.notification.showError("","");
      if(this.objbrand.Status==1){
        this.route.navigate(['/Brand/ActiveBrand']);
      }
      else{
        this.route.navigate(['/Brand/DeactiveBrand']);
      }
    })

  }

}
