import { Component, OnInit } from '@angular/core';
import { Brand } from '../../../Model/Brand';
import { BrandService } from '../../../Services/Brand/brand.service';

@Component({
  selector: 'app-deactive-brand',
  templateUrl: './deactive-brand.component.html',
  styleUrls: ['./deactive-brand.component.scss']
})
export class DeactiveBrandComponent implements OnInit {
  public lstbrand:Brand[]=new Array<Brand>();

  constructor(private service:BrandService) { }

  ngOnInit(): void {
    this.service.DeactiveBrand().subscribe((res:any)=>{
      this.lstbrand=res;
    })
  }

}
