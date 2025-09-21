import { Component, OnInit } from '@angular/core';
import { MenuItem } from 'primeng/api';

@Component({
  selector: 'app-menu',
  standalone: false,
  templateUrl: './menu.html',
  styleUrl: './menu.css'
})

export class MenuComponent implements OnInit {
  items: MenuItem[] = [];

  ngOnInit() {
    this.items = [
      { label: 'Home', icon: 'pi pi-home', routerLink: '/' },
      { label: 'Itens', icon: 'pi pi-list', routerLink: '/items' },
    ];
  }
}
