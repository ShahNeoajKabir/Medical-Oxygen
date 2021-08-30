import { Component, OnInit } from '@angular/core';
import { Categories } from '../../../Model/Categories';
import { CategoriesService } from '../../../Services/Categories/categories.service';

@Component({
  selector: 'app-deactive-categories',
  templateUrl: './deactive-categories.component.html',
  styleUrls: ['./deactive-categories.component.scss']
})
export class DeactiveCategoriesComponent implements OnInit {
  public lstcategories:Categories[]=new Array<Categories>();

  constructor(private categoriesservice:CategoriesService ) { }

  ngOnInit(): void {
    this.categoriesservice.DeactiveCategories().subscribe((res:any)=>{
      this.lstcategories=res;

    })
  }

}
