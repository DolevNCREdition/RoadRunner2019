import { Injectable } from '@angular/core';
import { HttpClient, HttpResponse } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class CustomerOrderService {

  lineItemApiUrl = 'https://localhost:44380/api/LineItem/';

  constructor(private http: HttpClient) { }

  getLineItems() {
    return this.http.get(this.lineItemApiUrl);
  }
}
