import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Attributesss } from '../../../Model/Attributess';
import { AttributesService } from '../../../Services/Attributes/attributes.service';

@Component({
  selector: 'app-active-attribute',
  templateUrl: './active-attribute.component.html',
  styleUrls: ['./active-attribute.component.scss']
})
export class ActiveAttributeComponent implements OnInit {

  public lstattribute:Attributesss[]=new Array<Attributesss>();

  constructor(private service:AttributesService , private router:Router) { }

  ngOnInit(): void {
    this.service.ActiveAttribute().subscribe((res:any)=>{
      this.lstattribute=res;
    })
  }

}
