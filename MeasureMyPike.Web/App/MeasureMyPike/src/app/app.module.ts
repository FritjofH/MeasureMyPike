import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpModule } from '@angular/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MaterialModule, MdCheckboxModule, MdInputModule, MdButtonModule, MdTooltipModule, MdDialogModule, MdSortModule, MdAutocompleteModule } from '@angular/material';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations/';
import { FlexLayoutModule } from '@angular/flex-layout';
import { RouterModule, Routes } from '@angular/router';
import { AUTH_PROVIDERS } from 'angular2-jwt';
import { ImageUploadModule } from 'angular2-image-upload';

import { AppComponent } from './app.component';

//Barrel
import { CatchService, CatchViewComponent } from './model/catch/catch';
import { UserService, UserRegisterViewComponent, UserLoginViewComponent, UserProfileViewComponent } from './model/user/user';

//Services
import { BrandService } from './service/brand/brand.service';
import { HomeService } from './service/home/home.service';

//Components
import { BrandViewComponent } from './view/brand/brand-view.component';
import { HomeViewComponent } from './view/home/home-view.component';

//Common
import { SaveChangesDialogComponent, UtilService, LogoutDialogComponent, ToolbarComponent, AuthGuard } from './common/index';

//Pipes
import { GramsToKilos, CentimeterToMeter } from './common/pipes/index';

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
        path: 'catch',
        component: CatchViewComponent
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
        ReactiveFormsModule,
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
        MdSortModule,
        MdAutocompleteModule,
        ImageUploadModule.forRoot()
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
