import { Component } from '@angular/core';
import { AnyForUntypedForms } from '@angular/forms';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'notes-app';
  text: string = "test";
  dateTest: Date = new Date(6,6,2003);
  myValue: number = 6 ;
  category: any;
}
