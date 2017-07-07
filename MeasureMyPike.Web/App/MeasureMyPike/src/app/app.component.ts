import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { UserService } from './service/user/user.service';
import { LogoutDialogComponent } from './common/logout/logoutDialog.component';

@Component({
    selector: 'app-root',
    templateUrl: './app.component.html',
    styleUrls: [ './app.component.scss' ],
    providers: [LogoutDialogComponent]
})

export class AppComponent {
    selectedOption: boolean;
    public title = 'MeasureMyPike';

    constructor(public router: Router, public userService: UserService, public logoutDialog: LogoutDialogComponent) {
    }

    public loggedIn() {
        return this.userService.loggedIn();
    }

    public logout() {
        this.logoutDialog.openDialog();
    }
}
