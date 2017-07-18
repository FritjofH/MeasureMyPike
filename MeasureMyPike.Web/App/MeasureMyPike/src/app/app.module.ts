import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpModule } from '@angular/http';
import { FormsModule } from '@angular/forms';
import { MaterialModule, MdCheckboxModule, MdInputModule, MdButtonModule, MdTooltipModule, MdDialogModule, MdSortModule } from '@angular/material';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations/';
import { FlexLayoutModule } from '@angular/flex-layout';
import { RouterModule, Routes } from '@angular/router';
import { AUTH_PROVIDERS } from 'angular2-jwt';

import { AppComponent } from './app.component';

import { BrandService } from './service/brand/brand.service';
import { UserService } from './service/user/user.service';
import { HomeService } from './service/home/home.service';
import { CatchService } from './service/catch/catch.service';

import { BrandViewComponent } from './view/brand-view/brand-view.component';
import { UserRegisterViewComponent } from './view/user-view/Register/userRegister-view.component';
import { UserLoginViewComponent } from './view/user-view/Login/userLogin-view.component';
import { UserProfileViewComponent } from './view/user-view/Profile/userProfile-view.component';
import { HomeViewComponent } from './view/home-view/home-view.component';
import { CatchViewComponent } from './view/catch-view/catch-view.component';

import { SaveChangesDialogComponent } from './common/saveChanges/saveChangesDialog.component';
import { LogoutDialogComponent } from './common/logout/logoutDialog.component';
import { ToolbarComponent } from './common/toolbar/toolbar.component';
import { AuthGuard } from './common/auth/auth.guard';
import { UtilService } from './common/util.service';
import { GramsToKilos } from './common/pipes/gramsToKilo.pipe';
import { CentimeterToMeter } from './common/pipes/centimeterToMeter.pipe';

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
        path: 'home',
        component: HomeViewComponent
    },
    {
        path: 'user/:username',
        component: UserProfileViewComponent
    },
    {
        path: 'login',
        component: UserLoginViewComponent
    },
    {
        path: '**',
        redirectTo: 'home'
    }
];

@NgModule({
    declarations: [
        AppComponent,
        ToolbarComponent,
        HomeViewComponent,
        BrandViewComponent,
        CatchViewComponent,
        UserRegisterViewComponent,
        UserLoginViewComponent,
        UserProfileViewComponent,
        LogoutDialogComponent,
        SaveChangesDialogComponent,
        GramsToKilos,
        CentimeterToMeter
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
        MdDialogModule,
        MdSortModule
    ],
    providers: [
        BrandService,
        UserService,
        HomeService,
        AuthGuard,
        AUTH_PROVIDERS,
        UtilService,
        CatchService
    ],
    entryComponents: [
        LogoutDialogComponent,
        SaveChangesDialogComponent
    ],
    bootstrap: [AppComponent]
})
export class AppModule { }
