import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Status } from '../../../Common/Enum';
import { Utility } from '../../../Common/Utility';
import { Brand } from '../../../Model/Brand';
import { BrandService } from '../../../Services/Brand/brand.service';
import { NotificationService } from '../../../Services/Notification/notification.service';

@Component({
  selector: 'app-delete-brand',
  templateUrl: './delete-brand.component.html',
  styleUrls: ['./delete-brand.component.scss']
})
export class DeleteBrandComponent implements OnInit {
  public objbrand:Brand=new Brand();
  public delete:Brand=new Brand();
  public lststatus:any;

  constructor(private service:BrandService, private route:Router, private utility:Utility, private activeroute:ActivatedRoute, private notification:NotificationService) { }

  ngOnInit(): void {
    this.lststatus=this.utility.enumToArray(Status);

    if(this.activeroute.snapshot.params['id']!==undefined){
      this.delete.BrandId=this.activeroute.snapshot.params['id'];
      this.service.GetById(this.delete).subscribe((res:any)=>{
        this.objbrand=res;
      })
    }
  }

  DeleteBrand(){
    this.service.DeleteBrand(this.objbrand).subscribe(res=>{
      if(res){

        this.notification.showDelete("","");
        this.route.navigate(['/Brand/ActiveBrand']);
      }
    },er=>{
      this.notification.showError("","");
      this.route.navigate(['/Brand/ActiveBrand'])
    })
  }

}
