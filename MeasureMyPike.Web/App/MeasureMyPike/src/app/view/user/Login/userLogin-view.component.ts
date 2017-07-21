import { Component } from '@angular/core';
import { User, UserService } from '../../../model/user/user';
import { Router } from '@angular/router';

@Component({
    selector: 'app-user-view',
    templateUrl: './userLogin-view.component.html',
    styleUrls: ['./userLogin-view.component.scss']
})

export class UserLoginViewComponent {
    private user: User;

    constructor(private userService: UserService, public router: Router) {  
        this.user.username = "";
        this.user.password = "";
      }

    public login(event) {
        event.preventDefault();
        this.userService.login(this.user);
    }

    public signup(event) {
        event.preventDefault();
        this.router.navigate(['signup']);
    }
}