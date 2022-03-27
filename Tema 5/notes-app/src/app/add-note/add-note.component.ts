import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-add-note',
  templateUrl: './add-note.component.html',
  styleUrls: ['./add-note.component.scss']
})
export class AddNoteComponent implements OnInit {

  title: string;
  description: string;
  
  constructor(private _router: Router, private _activatedRoute:ActivatedRoute) { }

  ngOnInit(): void {
    this._activatedRoute.params.subscribe(parameter=>{
      console.log(parameter["id"]);
    })
    this._activatedRoute.queryParams.subscribe(queryParams =>{
      console.log(queryParams['title']);
      console.log(queryParams['description']);
    })
  }

}
