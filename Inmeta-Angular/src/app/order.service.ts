import { Injectable } from '@angular/core';
import { Payload } from './payload';
import { HttpClient } from '@angular/common/http';
import {Observable} from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class OrderService {

  apiUrl = 'https://inmeta20181027060410.azurewebsites.net/api';

  constructor(private http: HttpClient) { }

  getOrders(): Observable<Payload[]> {
    return this.http.get<Payload[]>(this.apiUrl);
  }

  getOrder(id): Observable<Payload> {
    return this.http.get<Payload>(this.apiUrl + '/' + id);
  }

  updateOrder(order: Payload): Observable<any> {
    return this.http.put(this.apiUrl + '/' + order.orderId, order);
  }

  deleteOrder(order: Payload): Observable<any> {
    const deleteUrl = this.apiUrl + '/' + order.orderId;
    return this.http.delete(deleteUrl);
  }

}
