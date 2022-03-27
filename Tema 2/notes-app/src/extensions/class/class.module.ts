import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Student1Component } from './student1/student1.component';
import { Student2Component } from './student2/student2.component';
import { DepartmentModule } from '../departament/department.module';


@NgModule({
  declarations: [
    Student1Component,
    Student2Component
  ],
  imports: [
    CommonModule,
    DepartmentModule
  ],
  exports: [
    Student1Component,
    Student2Component
  ]

})
export class ClassModule { }
