import { Injectable } from '@angular/core';
import { Router, CanActivate } from '@angular/router';
import { tokenNotExpired } from 'angular2-jwt';
import { UserService } from '../../service/user/user.service';


@Injectable()
export class AuthGuard implements CanActivate {
    constructor(private router: Router, private userService: UserService) { 
}

    canActivate() {
        // Check to see if a user has a valid JWT
        if (tokenNotExpired()) {
            return true;
        }

        // If not, they redirect them to the login page
        this.userService.logout();
        return false;
    }
}