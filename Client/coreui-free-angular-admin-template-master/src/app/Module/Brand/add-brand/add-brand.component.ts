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

  ImageBaseData:string | ArrayBuffer=null;
  imageError: string;
  isImageSaved: boolean;
  cardImageBase64: string;
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

  handleFileInput(files: FileList) {
    let me = this;
    let file = files[0];
    let reader = new FileReader();
    reader.readAsDataURL(file);
    reader.onload = function () {
      console.log(reader.result);
      me.ImageBaseData=reader.result;
    };
    reader.onerror = function (error) {
      console.log('Error: ', error);
    };
 }
  btnUpload(){
    
    if(this.ImageBaseData==null){
      alert("Please select file");
    }else{     
      
      this.objbrand.Image=this.ImageBaseData.toString();
      
      
    }

  }
}
