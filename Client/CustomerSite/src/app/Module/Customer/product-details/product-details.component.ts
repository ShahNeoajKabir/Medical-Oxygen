import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Utility } from 'src/app/Common/Utility';
import { Product } from 'src/app/Model/Product';
import { AttributesService } from 'src/app/Services/Attributes/attributes.service';
import { BrandService } from 'src/app/Services/Brand/brand.service';
import { CategoriesService } from 'src/app/Services/Categories/categories.service';
import { NotificationService } from 'src/app/Services/Notification/notification.service';
import { ProductService } from 'src/app/Services/Product/product.service';

@Component({
  selector: 'app-product-details',
  templateUrl: './product-details.component.html',
  styleUrls: ['./product-details.component.css']
})
export class ProductDetailsComponent implements OnInit {

  public objproduct:Product=new Product();
  public editproduct:Product=new Product();
  public lstbrand:any;
  public lstcat:any;
  public lstat:any;



  constructor(private productservice:ProductService,private utility:Utility, private router:Router, private httpclient:HttpClient,
    private brandservice:BrandService , private categoriesservice:CategoriesService, private attributeservice:AttributesService,
    private ActivateRouter:ActivatedRoute, private notification:NotificationService) { }

  ngOnInit(): void {

    this.brandservice.ActiveBrand().subscribe((res:any)=>{
      this.lstbrand=res;
    })
    this.categoriesservice.ActiveCategories().subscribe((res:any)=>{
      this.lstcat=res;
    })
    this.attributeservice.ActiveAttribute().subscribe((res:any)=>{
      this.lstat=res;
    })
    
    if (this.ActivateRouter.snapshot.params['id'] !== undefined) {

      this.editproduct.ProductId = this.ActivateRouter.snapshot.params['id' ];
      this.productservice.GetById(this.editproduct).subscribe(( res: any) => {

        this.objproduct = res;
     });
      console.log(this.ActivateRouter.snapshot.params['id' ] );

    }
  }
}
