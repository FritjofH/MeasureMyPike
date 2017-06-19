import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpModule } from '@angular/http';

import { AppComponent } from './app.component';
import { BrandService } from './service/fish.service';
import { BrandViewComponent } from './view/fish-view/fish-view.component';

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
