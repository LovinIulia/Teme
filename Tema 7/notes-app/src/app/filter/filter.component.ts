import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { Category } from '../interfaces/category';
import { CategoryService } from '../services/category.service';
@Component({
  selector: 'app-filter',
  templateUrl: './filter.component.html',
  styleUrls: ['./filter.component.scss']
})
export class FilterComponent implements OnInit {
  @Output() emitSelectedFilter = new EventEmitter<string>();
  @Output() emitSearchByInput = new EventEmitter<string>();

  categories: Category[] = [];

  constructor(private service: CategoryService) { }
  
  selectFilter(category: string) {
    this.emitSelectedFilter.emit(category);
  }

  selectNote(title: string) {
    this.emitSearchByInput.emit(title);
  }

  ngOnInit(): void {
    this.categories = this.service.getCategories();
  }

}
