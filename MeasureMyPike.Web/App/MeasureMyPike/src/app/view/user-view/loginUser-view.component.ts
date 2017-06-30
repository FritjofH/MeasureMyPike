import { Component, OnInit } from '@angular/core';
import { UserService } from '../../service/user/user.service';

@Component({
    selector: 'app-user-view',
    templateUrl: './loginUser-view.component.html',
    styleUrls: ['./loginUser-view.component.scss']
})

export class LoginUserViewComponent implements OnInit {
    
    public username: string;
    public password: string;
    public submitted: boolean;
    public successfulLogin: boolean;

    constructor(private userService: UserService) { }

    ngOnInit(): void {
        this.username = "";
        this.password = "";
        this.submitted = false;
        this.successfulLogin = false;
    }


    public login() {
        this.submitted = true;
        this.userService.loginUser(this.username, this.password).subscribe(it => {
            this.successfulLogin = true;
        })
    }
}

