import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { ClassModule } from 'src/extensions/class/class.module';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    ClassModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
