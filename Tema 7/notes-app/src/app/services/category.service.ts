import { Injectable } from '@angular/core';
import { Category } from '../interfaces/category';

@Injectable({
  providedIn: 'root'
})
export class CategoryService {
  
categories: Category[]=[
  {name:'To do', id: '1'},
  {name:'Doing', id: '2'},
  {name:'Done', id: '3'}
];

  constructor() { }

  getCategories()
  {
    return this.categories;
  }
}
