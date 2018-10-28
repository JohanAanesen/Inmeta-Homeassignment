import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { OrdersComponent } from './orders/orders.component';
import { OrderEditComponent } from './order-edit/order-edit.component';
import {OrderNewComponent} from './order-new/order-new.component';

const routes: Routes = [
  { path: '', redirectTo: '/orders', pathMatch: 'full' },
  { path: 'order/:id', component: OrderEditComponent },
  { path: 'orders', component: OrdersComponent },
  { path: 'newOrder', component: OrderNewComponent },
];

@NgModule({
  imports: [ RouterModule.forRoot(routes) ],
  exports: [ RouterModule ]
})
export class AppRoutingModule {}
