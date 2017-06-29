import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpModule } from '@angular/http';
import { FormsModule } from '@angular/forms';
import { MaterialModule, MdCheckboxModule, MdInputModule, MdButtonModule, MdTooltipModule } from '@angular/material';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations/';
import { FlexLayoutModule } from '@angular/flex-layout';

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
        HttpModule,
        FormsModule,
        MaterialModule,
        MdCheckboxModule,
        MdInputModule,
        BrowserAnimationsModule,
        FlexLayoutModule,
        MdButtonModule,
        MdTooltipModule
    ],
    providers: [
        BrandService,
        UserService
    ],
    bootstrap: [AppComponent]
})
export class AppModule { }
