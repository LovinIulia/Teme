import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ToolsComponent } from './tools/tools.component';
import { FormsModule } from '@angular/forms';


@NgModule({
  declarations: [
    ToolsComponent
  ],
  imports: [
    CommonModule,
    FormsModule 
  ],
  exports:[
    ToolsComponent
  ]
})
export class ToolsModule { }
