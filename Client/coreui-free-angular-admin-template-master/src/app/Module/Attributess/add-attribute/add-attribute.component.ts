import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Status } from '../../../Common/Enum';
import { Utility } from '../../../Common/Utility';
import { Attributesss } from '../../../Model/Attributess';
import { AttributesService } from '../../../Services/Attributes/attributes.service';
import { NotificationService } from '../../../Services/Notification/notification.service';

@Component({
  selector: 'app-add-attribute',
  templateUrl: './add-attribute.component.html',
  styleUrls: ['./add-attribute.component.scss']
})
export class AddAttributeComponent implements OnInit {
  public objattribute:Attributesss=new Attributesss();
  public lstStatus:any;

  constructor(private service:AttributesService , private utility:Utility , private route:Router, private notification:NotificationService) { }

  ngOnInit(): void {
    this.lstStatus=this.utility.enumToArray(Status);
  }

  AddAttribute(){
    this.service.AddAttribute(this.objattribute).subscribe(res=>{
      this.notification.showSuccess("","");
      this.route.navigate(['/Attribute/ActiveAttribute']);
    }, er=>{
      this.notification.showError("","");
      this.route.navigate(['/Attribute/AddAttribute']);
    })
  }

}
