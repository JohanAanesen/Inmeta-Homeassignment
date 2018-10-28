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

  deleteOrder(order: Payload): Observable<Payload> {
    const deleteUrl = this.apiUrl + '/' + order.orderId;
    return this.http.delete(deleteUrl);
  }

}
