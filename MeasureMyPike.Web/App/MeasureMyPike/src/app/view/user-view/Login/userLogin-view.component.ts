import { Component } from '@angular/core';
import { UserService } from '../../../service/user/user.service';
import { Router } from '@angular/router';

@Component({
    selector: 'app-user-view',
    templateUrl: './userLogin-view.component.html',
    styleUrls: ['./userLogin-view.component.scss']
})

export class UserLoginViewComponent {

    username: string;
    password: string;

    constructor(private userService: UserService, public router: Router) {
        this.password = "";
        this.username = "";
    }

    login(event) {
        event.preventDefault();
        this.userService.login(this.username, this.password);
    }

    signup(event) {
        event.preventDefault();
        this.router.navigate(['signup']);
    }
}