import { Component, Input, OnInit } from '@angular/core';
import { Note } from '../interfaces/note';
import { NoteService } from '../services/note.service';

@Component({
  selector: 'app-note',
  templateUrl: './notes.component.html',
  styleUrls: ['./notes.component.scss']
})
export class NotesComponent implements OnInit {
  notes: Note[] = [];

  constructor(private service: NoteService) { }

  ngOnInit(): void {
    this.service.serviceCall();
    this.notes = this.service.getNotes();
  }
}
