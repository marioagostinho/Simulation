import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'keyValuePairs',
  standalone: true
})
export class KeyValuePairsPipe implements PipeTransform {
  transform(value: { [key: number]: number }, reverse: boolean = false): { key: number, value: number }[] {

    const keyValuePairs = Object.keys(value).map(key => ({
      key: Number(key),
      value: value[Number(key)]
    }));

    return reverse ? keyValuePairs.reverse() : keyValuePairs;
  }
}