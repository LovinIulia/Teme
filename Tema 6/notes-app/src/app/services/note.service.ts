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
      category: {id: '1', name: 'To do'},
    },
    {
      id: "Id2",
      title: "Second note",
      description: "This is the description for the second note",
      category: {id: '2', name: 'Doing'},
    },
    {
      id: "Id3",
      title: "Third note",
      description: "This is the description for the third note",
      category: {id: '3', name: 'Done'},
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
    const note: Note = {id : '1', title : title, description : description, category : category}
    this.notes.push(note);
  }
}
