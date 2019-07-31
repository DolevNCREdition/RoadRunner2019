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
  lineItems: any;

  constructor(private scannerService: ScannerService, private customerOrderService: CustomerOrderService) { }

  ngOnInit() {
    this.loadLineItems();
  }

  loadLineItems() {
    this.customerOrderService.getLineItems().subscribe((lineItems) => {
      this.lineItems = lineItems;
    });
  }

  scanProduct() {
    this.scannerService.scanProduct(this.code).subscribe((result: string) => {
      if (result === "true") {
        this.loadLineItems();
      }
    });
  }

}
