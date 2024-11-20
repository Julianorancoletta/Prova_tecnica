import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TableModule } from 'primeng/table';
import { HomeService } from './service/home.service';
import { MessageService } from 'primeng/api';
import { DialogService, DynamicDialogRef } from 'primeng/dynamicdialog';
import { TamanhoPipe } from './pipe/tamanho.pipe';
import { HttpClientModule } from '@angular/common/http';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [CommonModule,TableModule,TamanhoPipe,HttpClientModule],
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss',
  providers: [DialogService, HomeService, MessageService],
})
export class AppComponent  implements OnInit{

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
}
