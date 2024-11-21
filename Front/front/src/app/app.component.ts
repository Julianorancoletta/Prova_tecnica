import { Component, createComponent, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TableModule } from 'primeng/table';
import { HomeService } from './service/home.service';
import { MessageService } from 'primeng/api';
import { DialogService, DynamicDialogRef } from 'primeng/dynamicdialog';
import { TamanhoPipe } from './pipe/tamanho.pipe';
import { HttpClientModule } from '@angular/common/http';
import { RouterOutlet } from '@angular/router';
import { CreateComponent } from './cliente/create/create.component';
import { ButtonModule } from 'primeng/button';
import { DialogComponent } from "./dialog/dialog.component";

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [
    CommonModule,
    TableModule,
    TamanhoPipe,
    HttpClientModule,
    ButtonModule,
    DialogComponent
],
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss',
  providers: [DialogService, HomeService, MessageService],
})
export class AppComponent  implements OnInit{
  ref: DynamicDialogRef | undefined;
  client!: any[];

  constructor(
    private service: HomeService,
    public dialogService: DialogService,
    private messageService: MessageService
  ) {}

  ngOnInit() {
    this.getList();
  }

  getList() {
    this.service.getClienteList().subscribe((resp) => {
      this.client = resp;
    });
  }


  show() {
    this.ref = this.dialogService.open(CreateComponent, {
      header: 'Cadastro de cliente',
      width: '50vw',
      modal: true,
    });

    this.ref.onClose.subscribe((data: any) => {
      if (data)
        this.messageService.add({
          severity: 'success',
          summary: 'Cliente Cadastrada Com Sucesso',
        });
      this.getList();
    });
  }

  remover(item: any) {
    this.service.DeleteCliente(item).subscribe(() => {
      this.messageService.add({
        severity: 'success',
        summary: 'Cliente Deletada Com Sucesso'
      });
      this.getList();
    });
  }
}
