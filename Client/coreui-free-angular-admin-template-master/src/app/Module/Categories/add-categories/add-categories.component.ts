import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Status } from '../../../Common/Enum';
import { Utility } from '../../../Common/Utility';
import { Categories } from '../../../Model/Categories';
import { CategoriesService } from '../../../Services/Categories/categories.service';
import { NotificationService } from '../../../Services/Notification/notification.service';

@Component({
  selector: 'app-add-categories',
  templateUrl: './add-categories.component.html',
  styleUrls: ['./add-categories.component.scss']
})
export class AddCategoriesComponent implements OnInit {

  public objcategories:Categories=new Categories();
  public lstStatus:any;
  
  ImageBaseData:string | ArrayBuffer=null;
  imageError: string;
  isImageSaved: boolean;
  cardImageBase64: string;


  constructor(private categoriesserice:CategoriesService,private utility:Utility, private route:Router, private notification:NotificationService) { }

  ngOnInit(): void {
    this.lstStatus=this.utility.enumToArray(Status);
  }

  AddCategories(){
    this.categoriesserice.AddCategories(this.objcategories).subscribe(res=>{
      this.notification.showSuccess("","");
      this.route.navigate(['/Categories/ActiveCategories']);
    }, er=>{
      this.notification.showError("","");
      this.route.navigate(['/Categories/AddCategories']);
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
