import { NgModule, provideBrowserGlobalErrorListeners } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { AppRoutingModule } from './app-routing-module';
import { App } from './app';
import { Header } from './components/header/header';
import { Footer } from './components/footer/footer';
import { MenuComponent } from './components/menu/menu';
import { Items } from './pages/items/items';

import { TableModule } from 'primeng/table';
import { ButtonModule } from 'primeng/button';
import { DialogModule } from 'primeng/dialog';
import { InputTextModule } from 'primeng/inputtext';
import { ToastModule } from 'primeng/toast';
import { ToolbarModule } from 'primeng/toolbar';
import { MenubarModule } from 'primeng/menubar';
import { ConfirmDialogModule } from 'primeng/confirmdialog';
import { MessageService, ConfirmationService } from 'primeng/api';

import { provideAnimationsAsync } from '@angular/platform-browser/animations/async';
import { providePrimeNG } from 'primeng/config';
import Aura from '@primeuix/themes/aura';

@NgModule({
  declarations: [
    App,
    Header,
    Footer,
    MenuComponent,
    Items
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    FormsModule,
    HttpClientModule,
    TableModule,
    ButtonModule,
    DialogModule,
    InputTextModule,
    ToastModule,
    ToolbarModule,
    MenubarModule,
    ConfirmDialogModule
  ],
  providers: [MessageService, ConfirmationService,
    provideAnimationsAsync(),
    providePrimeNG({
      theme: {
        preset: Aura
      }
    })],
  bootstrap: [App]
})
export class AppModule { }
