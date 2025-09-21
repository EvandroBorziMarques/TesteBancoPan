import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { Items } from './pages/items/items';

const routes: Routes = [
  { path: '', redirectTo: '/items', pathMatch: 'full' },
  { path: 'items', component: Items },
  { path: '**', redirectTo: '/items' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
