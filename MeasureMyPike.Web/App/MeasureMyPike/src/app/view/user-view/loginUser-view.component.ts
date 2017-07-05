import { Component } from '@angular/core';
import { UserService } from '../../service/user/user.service';
import { Router } from '@angular/router';

@Component({
    selector: 'app-user-view',
    templateUrl: './loginUser-view.component.html',
    styleUrls: ['./loginUser-view.component.scss']
})

export class LoginUserViewComponent {
    constructor(private userService: UserService, public router: Router) {
    }

    login(event, username, password) {
        event.preventDefault();
        this.userService.login(username, password);
    }

    signup(event) {
        event.preventDefault();
        this.router.navigate(['signup']);
    }
}