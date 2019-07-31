import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ScannerComponent } from './components/scanner/scanner.component';
import { FormsModule } from '@angular/forms';
import { OrderLineComponent } from './components/order-line/order-line.component';


@NgModule({
  declarations: [
    AppComponent,
    ScannerComponent,
    OrderLineComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    AppRoutingModule,
    FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
