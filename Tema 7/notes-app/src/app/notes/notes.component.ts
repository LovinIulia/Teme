import { Component, Input, OnChanges, OnInit } from '@angular/core';
import { Note } from '../interfaces/note';
import { NoteService } from '../services/note.service';

@Component({
  selector: 'app-note',
  templateUrl: './notes.component.html',
  styleUrls: ['./notes.component.scss']
})
export class NotesComponent implements OnInit, OnChanges {
  notes: Note[] = [];
  @Input() selectedCategory: string;
  @Input() selectedNote: string;

  constructor(private service: NoteService) { }
  
  ngOnInit(): void {
    this.service.serviceCall();
    this.notes = this.service.getNotes();
  }

  ngOnChanges(): void {
    if (this.selectedCategory) 
    {
      this.notes = this.service.getFiltredNotes(this.selectedCategory);
    }
    else if(this.selectedNote)
    {
      this.notes = this.service.getFiltredNotesByTitle(this.selectedNote);
    }
    console.log()
  }

}
