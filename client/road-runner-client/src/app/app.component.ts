import { Component } from '@angular/core';
import { ProductService } from './services/product.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'road-runner-client';
  result = 'temp';

  constructor(private productService: ProductService) { }

  ngOnInit() {
    this.productService.getProduct(9).subscribe((product: any) => {
      this.result = product.name;
    });
  }
}
