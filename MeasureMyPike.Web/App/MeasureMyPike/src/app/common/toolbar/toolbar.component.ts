import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { UserService } from '../../service/user/user.service';
import { LogoutDialogComponent } from '../logout/logoutDialog.component';

@Component({
    selector: 'toolbar-component',
    templateUrl: './toolbar.component.html',
    styleUrls: [ './toolbar.component.scss' ],
    providers: [LogoutDialogComponent]
})

export class ToolbarComponent {
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
