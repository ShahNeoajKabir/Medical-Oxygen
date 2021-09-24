export class User{
    UserId:number;
    Image:string;
    UserName:string;
    Email:string
    Password:string;
    MobileNumber:string;
    UserType:number;
    CreatedBy:string;
    CreatedDate:Date;
    UpdatedBy:string;
    UpdatedDate:Date;
    Status:number;
    Role:number;
}

export class VmUsers{
    UserId: number=0;
    UserName: string='';
    Email: string='';
    MobileNo: string='';
    Status: number=0;
    RoleName:number;
}