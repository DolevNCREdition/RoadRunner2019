import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'app-order-line',
  templateUrl: './order-line.component.html',
  styleUrls: ['./order-line.component.scss']
})
export class OrderLineComponent implements OnInit {

  @Input() lineItems;

  constructor() { }

  ngOnInit() {
  }

}
