import { Component, OnInit } from '@angular/core';
import { Category } from '../interfaces/category';
import { CategoryService } from '../services/category.service';
import { NoteService } from '../services/note.service';

@Component({
  selector: 'app-add-note',
  templateUrl: './add-note.component.html',
  styleUrls: ['./add-note.component.scss']
})
export class AddNoteComponent implements OnInit { 
  title: string;
  description: string;
  categories: Category[] = [];
  selectedCategory: Category;
  
  constructor(
    private noteService: NoteService,
     private categoryService: CategoryService) { 
     }

  ngOnInit(): void {
    this.categories= this.categoryService.getCategories();
  }
  
  addNote(title: string, description: string, category: Category) {    
    this.noteService.addNote(title, description, category);  
  } 
}
