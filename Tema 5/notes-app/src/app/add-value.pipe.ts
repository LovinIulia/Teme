import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'addValue'
})
export class AddValuePipe implements PipeTransform {

  transform(value: number, addValue?: number): number {
    return isNaN(addValue)? value : value + addValue;
    ;
  }

}
