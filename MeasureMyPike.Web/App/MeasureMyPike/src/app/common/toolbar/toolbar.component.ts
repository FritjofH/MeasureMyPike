import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { UserService } from '../../service/user/user.service';
import { LogoutDialogComponent } from '../logout/logoutDialog.component';

@Component({
    selector: 'toolbar-component',
    templateUrl: './toolbar.component.html',
    styleUrls: ['./toolbar.component.scss'],
    providers: [LogoutDialogComponent]
})

export class ToolbarComponent {
    public selectedOption: boolean;
    public title = 'MeasureMyPike';
    public currentUsername: string;

    constructor(public router: Router, public userService: UserService, public logoutDialog: LogoutDialogComponent) {
        this.getCurrentUser();
    }

    public getCurrentUser() {
        var token = localStorage.getItem('token');
        this.currentUsername = this.userService.decodeUserToken(token);
    }

    public loggedIn() {
        return this.userService.loggedIn();
    }

    public logout() {
        this.logoutDialog.openDialog();
    }

public navigateToUser(currentUsername: string) {
    this.router.navigate(['/user/' + currentUsername]);
}
}
