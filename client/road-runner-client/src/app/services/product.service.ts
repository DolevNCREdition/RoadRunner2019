import { Injectable } from '@angular/core';
import { HttpClient, HttpResponse } from '@angular/common/http';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class ProductService {

  private _locations = null;

  productApiUrl = 'https://localhost:44380/api/Product/';

  constructor(private http: HttpClient) { }

  getProduct(id:number) {
    return this.http.get(this.productApiUrl + id);
  }

}
