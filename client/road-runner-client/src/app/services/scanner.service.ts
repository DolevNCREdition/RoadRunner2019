import { Injectable } from '@angular/core';
import { HttpClient, HttpResponse } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class ScannerService {
  scannerApiUrl = 'https://localhost:44380/api/Scanner/';

  constructor(private http: HttpClient) { }

  scanProduct(id: string) {
    return this.http.post(this.scannerApiUrl + id, null, { responseType: "text" });
  }
}
