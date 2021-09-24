import { Injectable } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
@Injectable({
  providedIn: 'root'
})
export class NotificationService {

  constructor(private toastr: ToastrService) { }

  showSuccess(message: string, title: string){
    this.toastr.success("Data Added successfully!!", "Successfull");
}

showUpdate(message: string, title: string){
  this.toastr.success("Data Update successfully!!", "Updated");
}

showError(message: string, title: string){
    this.toastr.error("Something is wrong !! Please Try Again !!", "Error Occure")
}

showInfo(message: string | undefined, title: string | undefined){
    this.toastr.info(message, title)
}

showDelete(message: string, title: string){
    this.toastr.warning("Data Remove successfully!!", "Deleted")
}

LoginFailed(message: string, title: string){
  this.toastr.error("Email or Password incorrect", "Error!!")
}
 


}