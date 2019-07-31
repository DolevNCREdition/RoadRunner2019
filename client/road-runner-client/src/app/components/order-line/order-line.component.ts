import { Component, OnInit, Input } from '@angular/core';
import { CustomerOrderService } from 'src/app/services/customer-order.service';

@Component({
  selector: 'app-order-line',
  templateUrl: './order-line.component.html',
  styleUrls: ['./order-line.component.scss']
})
export class OrderLineComponent implements OnInit {

  lineItems;

  private lastUpdateTime = -1;

  constructor(private customerOrderService: CustomerOrderService) { }

  ngOnInit() {
    this.loadLineItems();
    this.initLineItemInterval();
  }

  loadLineItems() {
    this.customerOrderService.getLineItems().subscribe((lineItems) => {
      this.lineItems = lineItems;
    });
  }

  initLineItemInterval() {
    setInterval(() => {
      this.customerOrderService.checkForUpdate().subscribe((lastUpdate) => {
        const lastUpdateTicks = Number(lastUpdate);
        if (lastUpdateTicks > this.lastUpdateTime) {
          this.loadLineItems();
          this.lastUpdateTime = lastUpdateTicks;
        }
      });
    }, 1000);
  }

}
