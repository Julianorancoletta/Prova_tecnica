import { Component, EventEmitter, Input, Output } from '@angular/core';
import { ConfirmationService, MessageService } from 'primeng/api';
import { ButtonModule } from 'primeng/button';
import { ConfirmDialogModule } from 'primeng/confirmdialog';
import { DialogService } from 'primeng/dynamicdialog';

@Component({
  selector: 'app-dialog',
  standalone: true,
  imports: [ConfirmDialogModule, ButtonModule],
  templateUrl: './dialog.component.html',
  styleUrl: './dialog.component.scss',
  providers: [ConfirmationService, MessageService, DialogService],
})
export class DialogComponent {
  @Output() panelClosed = new EventEmitter<number>();
  @Input() value :any;
  constructor(
    public dialogService: DialogService,
    private confirmationService: ConfirmationService,
    private messageService: MessageService
  ) {}


  confirm() {
    this.confirmationService.confirm({
      header: 'Remover',
      message: 'Tem certeza que deseja remover ?',
      accept: () => {
        this.messageService.add({
          severity: 'info',
          summary: 'Confirmed',
          detail: 'You have accepted',
          life: 3000,
        });
        this.panelClosed.emit(this.value);
      },
      reject: () => {
        this.messageService.add({
          severity: 'error',
          summary: 'Rejected',
          detail: 'You have rejected',
          life: 3000,
        });
      },
    });
  }
}
