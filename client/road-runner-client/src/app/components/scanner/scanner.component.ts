import { Component, OnInit } from '@angular/core';
import { ScannerService } from 'src/app/services/scanner.service';
import { CustomerOrderService } from 'src/app/services/customer-order.service';

@Component({
  selector: 'app-scanner',
  templateUrl: './scanner.component.html',
  styleUrls: ['./scanner.component.scss']
})
export class ScannerComponent implements OnInit {

  code: string = '';  

  constructor(private scannerService: ScannerService) { }

  ngOnInit() {
    
  }  

  scanProduct() {
    this.scannerService.scanProduct(this.code).subscribe((result: string) => {
      //if (result === "true") {
      //  this.loadLineItems();
      //}
    });
  }

}
