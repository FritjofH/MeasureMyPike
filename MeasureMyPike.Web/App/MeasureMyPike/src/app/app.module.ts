import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpModule } from '@angular/http';

import { AppComponent } from './app.component';
import { BrandService } from './service/brand/brand.service';
import { BrandViewComponent } from './view/brand-view/brand-view.component';
import { UserService } from './service/user/user.service';
import { UserViewComponent } from './view/user-view/user-view.component';

@NgModule({
    declarations: [
        AppComponent,
        BrandViewComponent,
        UserViewComponent
    ],
    imports: [
        BrowserModule,
        HttpModule
    ],
    providers: [
        BrandService,
        UserService
    ],
    bootstrap: [AppComponent]
})
export class AppModule { }
