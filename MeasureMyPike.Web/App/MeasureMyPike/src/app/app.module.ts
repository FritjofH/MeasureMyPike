import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpModule } from '@angular/http';
import { FormsModule } from '@angular/forms';
import { MaterialModule, MdCheckboxModule, MdInputModule, MdButtonModule, MdTooltipModule, MdDialogModule } from '@angular/material';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations/';
import { FlexLayoutModule } from '@angular/flex-layout';
import { RouterModule, Routes } from '@angular/router';

import { AUTH_PROVIDERS } from 'angular2-jwt';

import { AuthGuard } from './common/auth.guard';
import { AppComponent } from './app.component';
import { BrandService } from './service/brand/brand.service';
import { BrandViewComponent } from './view/brand-view/brand-view.component';
import { UserService } from './service/user/user.service';
import { UserRegisterViewComponent } from './view/user-view/Register/userRegister-view.component';
import { UserLoginViewComponent } from './view/user-view/Login/userLogin-view.component';
import { UserProfileViewComponent } from './view/user-view/Profile/userProfile-view.component';
import { LogoutDialogComponent } from './common/logout/logoutDialog.component';

const appRoutes: Routes = [
    {
        path: 'signup',
        component: UserRegisterViewComponent
    },
    {
        path: 'brands',
        component: BrandViewComponent, canActivate: [AuthGuard]
    },
    {
        path: '',
        component: UserLoginViewComponent
    },
    {
        path: '**',
        component: UserLoginViewComponent
    },
    {
        path: 'login',
        component: UserLoginViewComponent
    }
];

@NgModule({
    declarations: [
        AppComponent,
        BrandViewComponent,
        UserRegisterViewComponent,
        UserLoginViewComponent,
        UserProfileViewComponent,
        LogoutDialogComponent
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
        MdTooltipModule,
        MdDialogModule
    ],
    providers: [
        BrandService,
        UserService,
        AuthGuard,
        AUTH_PROVIDERS
    ],
    entryComponents: [
        LogoutDialogComponent
    ],
    bootstrap: [AppComponent]
})
export class AppModule { }
