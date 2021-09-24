export class Product{
    ProductId:number=0;
    CategoriesId:number=0;
    BrandId:number=0;
    AttributeId:number=0;
    ProductCode:string="";
    Title:string="";
    Image:string="";
    RegularPrice:number=0;
    DiscountPrice:number=0;
    Description:string="";
    StockQuantity:number=0;
    CreatedBy:string="";
    CreatedDate:Date | undefined;
    UpdatedBy:string="";
    UpdatedDate:Date | undefined;
    Status:number=0;
    BrandName:string="";

    CategoriesName :string="";
    AttributeValue :string="";

}