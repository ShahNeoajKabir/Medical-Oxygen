import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Status, UserType } from '../../../Common/Enum';
import { Utility } from '../../../Common/Utility';
import { User } from '../../../Model/User';
import { NotificationService } from '../../../Services/Notification/notification.service';
import { UserService } from '../../../Services/User/user.service';

@Component({
  selector: 'app-update-user',
  templateUrl: './update-user.component.html',
  styleUrls: ['./update-user.component.scss']
})
export class UpdateUserComponent implements OnInit {
  public objuser:User=new User();
  public edituser:User=new User();
  public lststatus:any;
  public lstusertype:any;

  public userid:any;
  
  ImageBaseData:string | ArrayBuffer=null;
  imageError: string;
  isImageSaved: boolean;
  cardImageBase64: string;

  constructor(private userservice:UserService,private utility:Utility, private router:Router, private httpclient:HttpClient,private ActivateRouter:ActivatedRoute, private notification:NotificationService) { }

  ngOnInit(): void {
    this.lststatus=this.utility.enumToArray(Status);
    this.lstusertype=this.utility.enumToArray(UserType);


    if (this.ActivateRouter.snapshot.params['id'] !== undefined) {

      this.edituser.UserId = this.ActivateRouter.snapshot.params['id' ];
      this.userservice.GetById(this.edituser).subscribe(( res: any) => {

        this.objuser = res;
     });

    }
  }

  UpdateUser(){
    this.userservice.UpdateUser(this.objuser).subscribe(res=>{
      console.log(res);
      if(res){
        this.notification.showUpdate("","");
        this.router.navigate(['/User/ListAllUser']);
      }
    },er=>{
      this.notification.showError("","");
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
      
      this.objuser.Image=this.ImageBaseData.toString();
      
      
    }
  }

}
