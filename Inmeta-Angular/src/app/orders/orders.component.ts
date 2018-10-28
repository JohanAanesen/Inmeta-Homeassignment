import {Component, Injectable, OnInit} from '@angular/core';
import { OrderService } from '../order.service';
import {Payload} from '../payload';

@Component({
  selector: 'app-orders',
  templateUrl: './orders.component.html',
  styleUrls: ['./orders.component.css']
})

@Injectable()
export class OrdersComponent implements OnInit {

  title = 'Orders';
  results;
  apiUrl = 'https://inmeta20181027060410.azurewebsites.net/api';

  constructor(private orderService: OrderService) {
  }

  ngOnInit(): void {
    this.getOrders();
  }

  getOrders(): void {
    this.orderService.getOrders().subscribe(results => this.results = results);
  }

  deleteOrder(result: Payload): void {
    this.results = this.results.filter(h => h !== result);
    this.orderService.deleteOrder(result).subscribe();
  }

}
