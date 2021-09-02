import { Component, OnInit } from '@angular/core';
import { Brand } from '../../../Model/Brand';
import { BrandService } from '../../../Services/Brand/brand.service';

@Component({
  selector: 'app-active-brand',
  templateUrl: './active-brand.component.html',
  styleUrls: ['./active-brand.component.scss']
})
export class ActiveBrandComponent implements OnInit {
  public lstbrand:Brand[]=new Array<Brand>();

  constructor(private service:BrandService) { }

  ngOnInit(): void {
    this.service.ActiveBrand().subscribe((res:any)=>{
      this.lstbrand=res;
    })
  }

}
