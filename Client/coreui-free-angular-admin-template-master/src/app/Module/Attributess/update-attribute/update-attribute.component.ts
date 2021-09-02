import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Status } from '../../../Common/Enum';
import { Utility } from '../../../Common/Utility';
import { Attributesss } from '../../../Model/Attributess';
import { AttributesService } from '../../../Services/Attributes/attributes.service';
import { NotificationService } from '../../../Services/Notification/notification.service';

@Component({
  selector: 'app-update-attribute',
  templateUrl: './update-attribute.component.html',
  styleUrls: ['./update-attribute.component.scss']
})
export class UpdateAttributeComponent implements OnInit {
  public objattribute:Attributesss=new Attributesss();
  public editattribute:Attributesss=new Attributesss();
  public lstStatus:any;

  constructor(private service:AttributesService , private utility:Utility , private route:Router, private notification:NotificationService , private activater:ActivatedRoute) { }

  ngOnInit(): void {
    this.lstStatus=this.utility.enumToArray(Status);
    if(this.activater.snapshot.params['id']!==undefined){
      this.editattribute.AttributeId=this.activater.snapshot.params['id'];
      this.service.GetById(this.editattribute).subscribe((res:any)=>{
        this.objattribute=res;
      })
    }
  }


  UpdateAttribute(){
    this.service.UpdateAttribute(this.objattribute).subscribe(res=>{
      if(res){
        this.notification.showUpdate("","");
        if(this.objattribute.Status==1){
          this.route.navigate(['/Attribute/ActiveAttribute']);
        }
        else{
          this.route.navigate(['/Attribute/DeactiveAttribute']);
        }
      }
      
    }, er=>{
      this.notification.showError("","");
      if(this.objattribute.Status==1){
        this.route.navigate(['/Attribute/ActiveAttribute']);
      }
      else{
        this.route.navigate(['/Attribute/DeactiveAttribute']);
      }
    })
  }

}
