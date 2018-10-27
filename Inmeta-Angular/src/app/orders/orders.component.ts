import {Component, Injectable, OnInit} from '@angular/core';
import { HttpClient } from '@angular/common/http';
import {Payload} from '../payload';

@Component({
  selector: 'app-orders',
  templateUrl: './orders.component.html',
  styleUrls: ['./orders.component.css']
})

@Injectable()
export class OrdersComponent implements OnInit {

  title = 'Orders';
  results: Payload[];
  apiUrl = 'https://inmeta20181027060410.azurewebsites.net/api';

  constructor(private http: HttpClient) {
  }

  ngOnInit(): void {
    this.http.get<Payload[]>(this.apiUrl).subscribe(data => {
      this.results = data;
      console.log(this.results);
    });

  }

}
