import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DepartmentCategoryComponent } from './department-category/department-category.component';



@NgModule({
  declarations: [
    DepartmentCategoryComponent
  ],
  imports: [
    CommonModule
  ],
  exports:[
    DepartmentCategoryComponent 
  ]
})
export class DepartmentModule { }
