import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpModule } from '@angular/http';

import { AppComponent } from './app.component';
import { BrandService } from './service/brand.service';
import { BrandViewComponent } from './view/brand-view/brand-view.component';

@NgModule({
  declarations: [
    AppComponent,
    BrandViewComponent
  ],
  imports: [
      BrowserModule,
      HttpModule
  ],
  providers: [
      BrandService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
