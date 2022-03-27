import { Injectable } from '@angular/core';
import { Category } from '../interfaces/category';
import { Note } from '../interfaces/note';

@Injectable({
  providedIn: 'root'
})
export class NoteService {
  notes: Note[]=[
    {
      id: "Id1",
      title: "First note",
      description: "This is the description for the first note",
      category: "1"
    },
    {
      id: "Id2",
      title: "Second note",
      description: "This is the description for the second note",
      category: "2"
    },
    {
      id: "Id3",
      title: "Third note",
      description: "This is the description for the third note",
      category: "3"
    }
  ];

  constructor() { }

  serviceCall() {
    console.log("Note service was called");
  }

  getNotes() {
    return this.notes;
  }

  addNote(title: string, description: string, category: Category)
  {
    const note: Note = {id : "1", title : title, description : description, category: "1"}
    this.notes.push(note);
  }

  getFiltredNotes(argCategory: string) {
    return this.notes.filter(note => note.category === argCategory);
  }

  getFiltredNotesByTitle(argTitle: string) {
    return this.notes.filter(note => note.title.toLowerCase().includes(argTitle.toLowerCase()) 
    || note.description.toLowerCase().includes(argTitle.toLowerCase()));
  }

}
