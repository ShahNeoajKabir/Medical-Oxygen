import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Status } from '../../../Common/Enum';
import { Utility } from '../../../Common/Utility';
import { Product } from '../../../Model/Product';
import { AttributesService } from '../../../Services/Attributes/attributes.service';
import { BrandService } from '../../../Services/Brand/brand.service';
import { CategoriesService } from '../../../Services/Categories/categories.service';
import { NotificationService } from '../../../Services/Notification/notification.service';
import { ProductService } from '../../../Services/Product/product.service';

@Component({
  selector: 'app-add-product',
  templateUrl: './add-product.component.html',
  styleUrls: ['./add-product.component.scss']
})
export class AddProductComponent implements OnInit {
  public objproduct:Product=new Product();
  public lstCategories:any;
  public lstBrand:any;
  public lstAttribut:any;
  public lstStatus:any;
  ImageBaseData:string | ArrayBuffer=null;
  imageError: string;
  isImageSaved: boolean;
  cardImageBase64: string;

  constructor(private productservice:ProductService,
    private categorieservice:CategoriesService,
    private brandservice:BrandService,
    private attributeservice:AttributesService,
    private route:Router,
    private utility:Utility,
    private notificatoin:NotificationService
    ) { }

  ngOnInit(): void {
    this.lstStatus=this.utility.enumToArray(Status);

    this.categorieservice.ActiveCategories().subscribe((res:any)=>{
      this.lstCategories=res;
    })


    this.brandservice.ActiveBrand().subscribe((res:any)=>{
      this.lstBrand=res;
    })

    this.attributeservice.ActiveAttribute().subscribe((res:any)=>{
      this.lstAttribut=res;
    })
  }


  AddProduct(){
    this.productservice.AddProduct(this.objproduct).subscribe(res=>{
      this.notificatoin.showSuccess("","");
      if(this.objproduct.Status==1){
        this.route.navigate(['/Product/ActiveProduct']);
      }

      else{
        this.route.navigate(['/Product/DeactiveProduct']);
      }
    },er=>{
      this.notificatoin.showError("","");
      this.route.navigate(['/Product/AddProduct']);
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
      
      this.objproduct.Image=this.ImageBaseData.toString();
      
      
    }
  }

}
