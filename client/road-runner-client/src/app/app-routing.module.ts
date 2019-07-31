import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ScannerComponent } from './components/scanner/scanner.component';


const routes: Routes = [
  { path: 'scanner', component: ScannerComponent },  
  { path: '**', component: ScannerComponent }];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
