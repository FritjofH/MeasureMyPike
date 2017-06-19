import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpModule } from '@angular/http';

import { AppComponent } from './app.component';
import { FishService } from './service/fish.service';
import { FishViewComponent } from './view/fish-view/fish-view.component';

@NgModule({
  declarations: [
    AppComponent,
    FishViewComponent
  ],
  imports: [
      BrowserModule,
      HttpModule
  ],
  providers: [
      FishService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
