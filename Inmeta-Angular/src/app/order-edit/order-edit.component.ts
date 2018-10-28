import {Component, Input, OnInit} from '@angular/core';
import {Payload} from '../payload';
import {OrderService} from '../order.service';
import {ActivatedRoute} from '@angular/router';
import {Location} from '@angular/common';

@Component({
  selector: 'app-order-edit',
  templateUrl: './order-edit.component.html',
  styleUrls: ['./order-edit.component.css']
})
export class OrderEditComponent implements OnInit {
  order: Payload;


  constructor(
    private orderService: OrderService,
    private route: ActivatedRoute,
    private location: Location
  ) { }

  services = ['Moving', 'Packing', 'Cleaning'];

  ngOnInit() {
    this.getOrder();
  }

  getOrder(): void {
    const id = +this.route.snapshot.paramMap.get('id');
    this.orderService.getOrder(id)
      .subscribe(order => {this.order = order; console.log(this.order); });
  }

  deleteOrder(payload: Payload): void {
    this.orderService.deleteOrder(payload).subscribe();
  }

  updateOrder(): void {
    this.orderService.updateOrder(this.order)
      .subscribe(() => this.goBack());
  }

  goBack(): void {
    this.location.back();
  }

}
