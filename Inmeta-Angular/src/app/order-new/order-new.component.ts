import { Component, OnInit } from '@angular/core';
import {Payload} from '../payload';
import {OrderService} from '../order.service';
import {Location} from '@angular/common';

@Component({
  selector: 'app-order-new',
  templateUrl: './order-new.component.html',
  styleUrls: ['./order-new.component.css']
})
export class OrderNewComponent implements OnInit {

  order: Payload;

  services = ['Moving', 'Packing', 'Cleaning'];

  constructor(
    private orderService: OrderService,
    private location: Location
  ) { }

  ngOnInit() {
    this.order = new Payload();
  }

  saveOrder() {
    console.log('eyo');
    this.orderService.newOrder(this.order).subscribe(() => this.goBack());
  }

  goBack(): void {
    this.location.back();
  }

}
