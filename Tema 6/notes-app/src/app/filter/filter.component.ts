import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { Category } from '../interfaces/category';
import { CategoryService } from '../services/category.service';
@Component({
  selector: 'app-filter',
  templateUrl: './filter.component.html',
  styleUrls: ['./filter.component.scss']
})
export class FilterComponent implements OnInit {
  categories: Category[] = [];

  constructor(private service: CategoryService) { }

  ngOnInit(): void {
    this.categories = this.service.getCategories();
  }

}
