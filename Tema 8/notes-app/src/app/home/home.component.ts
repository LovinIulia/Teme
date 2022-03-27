import { Component, Input, OnInit, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {
  category : string;
  termSearch: string; 

  constructor() { }

  receiveCategory(categId: string) {
    this.category = categId;
    console.log(this.category)
  }

  receiveNote(term: string) {
    this.termSearch = term;
  }

  ngOnInit(): void {
  }

  
}
