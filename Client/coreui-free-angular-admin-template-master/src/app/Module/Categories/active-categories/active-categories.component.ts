import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Categories } from '../../../Model/Categories';
import { CategoriesService } from '../../../Services/Categories/categories.service';

@Component({
  selector: 'app-active-categories',
  templateUrl: './active-categories.component.html',
  styleUrls: ['./active-categories.component.scss']
})
export class ActiveCategoriesComponent implements OnInit {
  public lstcategories:Categories[]=new Array<Categories>();

  constructor(private categoriesservice:CategoriesService , private router:Router) { }

  ngOnInit(): void {
    this.categoriesservice.ActiveCategories().subscribe((res:any)=>{
      this.lstcategories=res;
    })
  }

}
