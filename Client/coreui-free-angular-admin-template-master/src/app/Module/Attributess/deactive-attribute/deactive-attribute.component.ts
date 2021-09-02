import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Attributesss } from '../../../Model/Attributess';
import { AttributesService } from '../../../Services/Attributes/attributes.service';

@Component({
  selector: 'app-deactive-attribute',
  templateUrl: './deactive-attribute.component.html',
  styleUrls: ['./deactive-attribute.component.scss']
})
export class DeactiveAttributeComponent implements OnInit {
  public lstattribute:Attributesss[]=new Array<Attributesss>();

  constructor(private service:AttributesService , private router:Router) { }

  ngOnInit(): void {
    this.service.DeactiveAttribute().subscribe((res:any)=>{
      this.lstattribute=res;
    })
  }

}
