import { Component, OnInit } from '@angular/core';
import { ApiService } from '../../services/api.service';
import { MessageService, ConfirmationService } from 'primeng/api';

@Component({
  selector: 'app-items',
  standalone: false,
  templateUrl: './items.html',
  styleUrl: './items.css',
  providers: [MessageService, ConfirmationService]
})

export class Items implements OnInit {
  items: any[] = [];
  itemDialog: boolean = false;
  item: any = {
    endereco: {}
  };

  constructor(private api: ApiService, private messageService: MessageService, private confirmationService: ConfirmationService) { }

  ngOnInit() {
    this.loadItems();
  }

  loadItems() {
    this.api.getItems().subscribe((result: any) => {
      this.items = result.map((item: any) => {
        return {
          id: item.id,
          nome: item.nome,
          telefone: item.telefone,
          cpf: item.cpf,
          dataNascimento: this.formatDate(item.dataNascimento),
          cnpj: item.cnpj,
          razaoSocial: item.razaoSocial,
          endereco: {
            cep: item.endereco.cep,
            logradouro: item.endereco.logradouro,
            complemento: item.endereco.complemento,
            bairro: item.endereco.bairro,
            uf: item.endereco.uf,
            estado: item.endereco.estado
          }
        }
      });
    });
  }

  openNew() {
    this.item = { endereco: {} };
    this.itemDialog = true;
  }

  saveItem() {
    if (this.item.id) {
      this.api.updateItem(this.item.id, this.item).subscribe({
        next: () => {
          this.loadItems();
          this.itemDialog = false;
          this.showSuccess('Item atualizado com sucesso!');
        },
        error: err => this.showError(err)
      });
    } else {
      this.api.createItem(this.item).subscribe({
        next: () => {
          this.loadItems();
          this.itemDialog = false;
          this.showSuccess('Item criado com sucesso!');
        },
        error: err => this.showError(err)
      });
    }
  }

  editItem(item: any) {
    this.item = {
      ...item,
      endereco: item.endereco ? { ...item.endereco } : {}
    };
    this.itemDialog = true;
  }

  confirmDelete(item: any) {
    this.confirmationService.confirm({
      message: `Deseja excluir o item <b>${item.nome}</b>?`,
      header: 'Confirmar Exclusão',
      icon: 'pi pi-exclamation-triangle',
      accept: () => this.deleteItem(item),
    });
  }

  deleteItem(item: any) {
    this.api.deleteItem(item.id).subscribe({
      next: () => {
        this.loadItems();
        this.showSuccess('Item deletado com sucesso!');
      },
      error: err => this.showError(err)
    });
  }

  formatDate(value: Date) {
    if (value) {
      var newValue = value.toString();
      const ano = newValue.substring(0, 4);
      const mes = newValue.substring(5, 7);
      const dia = newValue.substring(8, 10);
      return `${dia}/${mes}/${ano}`
    }
    return ``
  }

  showSuccess(detail: string) {
    this.messageService.add({ severity: 'success', summary: 'Sucesso', detail });
  }

  showError(detail: string) {
    this.messageService.add({ severity: 'error', summary: 'Erro', detail });
  }
}
