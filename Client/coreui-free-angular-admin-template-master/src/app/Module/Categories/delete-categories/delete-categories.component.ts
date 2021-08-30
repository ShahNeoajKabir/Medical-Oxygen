import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Status } from '../../../Common/Enum';
import { Utility } from '../../../Common/Utility';
import { Categories } from '../../../Model/Categories';
import { CategoriesService } from '../../../Services/Categories/categories.service';
import { NotificationService } from '../../../Services/Notification/notification.service';

@Component({
  selector: 'app-delete-categories',
  templateUrl: './delete-categories.component.html',
  styleUrls: ['./delete-categories.component.scss']
})
export class DeleteCategoriesComponent implements OnInit {

  public objcategories:Categories=new Categories();
  public deletecategories:Categories=new Categories();
  public lstStatus:any;

  public userid:any;

  constructor(private service:CategoriesService,private utility:Utility, private router:Router, private httpclient:HttpClient,private ActivateRouter:ActivatedRoute, private notification:NotificationService) { }

  ngOnInit(): void {
    this.lstStatus=this.utility.enumToArray(Status);


    if (this.ActivateRouter.snapshot.params['id'] !== undefined) {

      this.deletecategories.CategoriesId = this.ActivateRouter.snapshot.params['id' ];
      this.service.GetById(this.deletecategories).subscribe(( res: any) => {

        this.objcategories = res;
        console.log(res);
     });
      console.log(this.ActivateRouter.snapshot.params['id' ] );

    }
  }

  DeleteCategories(){
    this.service.DeleteCategories(this.objcategories).subscribe(res=>{
      console.log(res);
      if(res){
        this.notification.showDelete("","");
        this.router.navigate(['/Categories/ActiveCategories']);
      }
    },er=>{
      this.notification.showError("","");
      this.router.navigate(['/Categories/ActiveCategories']);
    })
  }

}
