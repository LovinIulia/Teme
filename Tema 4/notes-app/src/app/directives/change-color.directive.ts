import { Directive, ElementRef, HostListener, Input } from '@angular/core';

@Directive({
  selector: '[appChangeColor]'
})
export class ChangeColorDirective {

  @Input('appChangeColor') changeColor: string = '';

  constructor(el: ElementRef) {
    el.nativeElement.style.backgroundColor = this.changeColor;
 }
 
}