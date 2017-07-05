import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpModule } from '@angular/http';
import { FormsModule } from '@angular/forms';
import { MaterialModule, MdCheckboxModule, MdInputModule, MdButtonModule, MdTooltipModule } from '@angular/material';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations/';
import { FlexLayoutModule } from '@angular/flex-layout';
import { RouterModule, Routes } from '@angular/router';

import { AUTH_PROVIDERS } from 'angular2-jwt';

import { AuthGuard } from './common/auth.guard';
import { AppComponent } from './app.component';
import { BrandService } from './service/brand/brand.service';
import { BrandViewComponent } from './view/brand-view/brand-view.component';
import { UserService } from './service/user/user.service';
import { RegisterUserViewComponent } from './view/user-view/registerUser-view.component';
import { LoginUserViewComponent } from './view/user-view/loginUser-view.component';

const appRoutes: Routes = [
    {
        path: 'signup',
        component: RegisterUserViewComponent
    },
    {
        path: 'brands',
        component: BrandViewComponent, canActivate: [AuthGuard]
    },
    {
        path: '',
        component: LoginUserViewComponent
    },
    {
        path: '**',
        component: LoginUserViewComponent
    },
    {
        path: 'login',
        component: LoginUserViewComponent
    }
];

@NgModule({
    declarations: [
        AppComponent,
        BrandViewComponent,
        RegisterUserViewComponent,
        LoginUserViewComponent
    ],
    imports: [
        BrowserModule,
        HttpModule,
        FormsModule,
        RouterModule.forRoot(
            appRoutes, { enableTracing: true }
        ),
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
        UserService,
        AuthGuard,
        AUTH_PROVIDERS
    ],
    bootstrap: [AppComponent]
})
export class AppModule { }
