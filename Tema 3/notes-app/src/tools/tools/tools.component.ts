import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-tools',
  templateUrl: './tools.component.html',
  styleUrls: ['./tools.component.scss']
})
export class ToolsComponent implements OnInit {
  title: string = "title";
  backgroundColor: string ="";
  
  constructor() { }

  ngOnInit(): void {
  }

  setColor(color:string) { this.backgroundColor = color };
  

}
