import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Status } from '../../../Common/Enum';
import { Utility } from '../../../Common/Utility';
import { Categories } from '../../../Model/Categories';
import { CategoriesService } from '../../../Services/Categories/categories.service';
import { NotificationService } from '../../../Services/Notification/notification.service';

@Component({
  selector: 'app-update-categories',
  templateUrl: './update-categories.component.html',
  styleUrls: ['./update-categories.component.scss']
})
export class UpdateCategoriesComponent implements OnInit {

  public objcategories:Categories=new Categories();
  public editcategories:Categories=new Categories();
  public lstStatus:any;

  public userid:any;
  ImageBaseData:string | ArrayBuffer=null;
  imageError: string;
  isImageSaved: boolean;
  cardImageBase64: string;

  constructor(private service:CategoriesService,private utility:Utility, private router:Router, private httpclient:HttpClient,private ActivateRouter:ActivatedRoute, private notification:NotificationService) { }

  ngOnInit(): void {
    this.lstStatus=this.utility.enumToArray(Status);


    if (this.ActivateRouter.snapshot.params['id'] !== undefined) {

      this.editcategories.CategoriesId = this.ActivateRouter.snapshot.params['id' ];
      this.service.GetById(this.editcategories).subscribe(( res: any) => {

        this.objcategories = res;
        console.log(res);
     });
      console.log(this.ActivateRouter.snapshot.params['id' ] );

    }
  }

  UpdateCategories(){
    this.service.UpdateCategories(this.objcategories).subscribe(res=>{
      console.log(res);
      if(res){
        this.notification.showUpdate("","");
        this.router.navigate(['/Categories/ActiveCategories']);
      }
    },er=>{
      this.notification.showError("","");
      this.router.navigate(['/Categories/ActiveCategories']);
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
      
      this.objcategories.Image=this.ImageBaseData.toString();
      
      
    }
  }

}
