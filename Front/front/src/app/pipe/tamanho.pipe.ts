import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'tamanho',
  standalone: true
})
export class TamanhoPipe implements PipeTransform {

  transform(value: number): string {
    switch (value) {
      case 0:
        return 'Pequena';
      case 1:
        return 'Média';
      case 2:
        return 'Grande';
      default:
        return 'Desconhecido'; // Caso o valor não seja válido
    }
  }
}