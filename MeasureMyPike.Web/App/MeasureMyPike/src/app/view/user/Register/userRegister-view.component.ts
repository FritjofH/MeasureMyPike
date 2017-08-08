import { Component, OnInit } from '@angular/core';
import { User, UserService } from '../../../model/user/user';
import { Router } from '@angular/router';

@Component({
    selector: 'app-user-view',
    templateUrl: './userRegister-view.component.html',
    styleUrls: ['./userRegister-view.component.scss']
})

export class UserRegisterViewComponent implements OnInit {
    public user: User = {
        firstName: "",
        lastName: "",
        username: "",
        password: "",
        memberSince: ""
    };
    public submitted: boolean;

    constructor(private userService: UserService, private router: Router) {    }

    ngOnInit(): void {
        this.submitted = false;
    }


    public registerUser() {
        this.submitted = true;
        this.userService.registerUser(this.user).subscribe(it => {
        })
        this.router.navigate(['/login']);
    }
}

