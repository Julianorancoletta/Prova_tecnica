import { Component } from '@angular/core';
import { FormControl, FormGroup, FormsModule, ReactiveFormsModule } from '@angular/forms';
import { ButtonModule } from 'primeng/button';
import { InputTextModule } from 'primeng/inputtext';
import { HomeService } from '../../service/home.service';
import { RadioButtonModule } from 'primeng/radiobutton';
import { CommonModule } from '@angular/common';
import { DynamicDialogConfig, DynamicDialogRef } from 'primeng/dynamicdialog';


@Component({
  selector: 'app-create',
  standalone: true,
  imports: [
    FormsModule, 
    InputTextModule, 
    ButtonModule, 
    ReactiveFormsModule,
    RadioButtonModule,
    CommonModule],
  templateUrl: './create.component.html',
  styleUrl: './create.component.scss',
  providers: [HomeService],
})
export class CreateComponent {

  Updatecliente:any;

  constructor(
    private service: HomeService,
    private ref: DynamicDialogRef,
    public config: DynamicDialogConfig
  ) {
    this.Updatecliente = this.config.data?.cliente; // Acessa o valor passado
  }

  ClienteFrom = new FormGroup({
    nomeEmpresa: new FormControl<string>(''),
    porte: new FormControl<number>(0)
  });

  TipoPorte: any[] = [
    { name: 'Pequena', key: 0 },
    { name: 'Média', key: 1 },
    { name: 'Grande', key: 2 },
    
  ];

  Salvar(){
    this.service
    .PostCliente(this.ClienteFrom)
    .subscribe((resp) => {
      this.ClienteFrom.reset();
      this.ref.close(resp);
    });
  }
  
}
