import { Component, OnInit } from '@angular/core';
import { UserService } from '../../service/user/user.service';

@Component({
    selector: 'app-user-view',
    templateUrl: './registerUser-view.component.html',
    styleUrls: ['./registerUser-view.component.scss']
})

export class RegisterUserViewComponent implements OnInit {

    public firstName: string;
    public lastName: string;
    public username: string;
    public password: string;
    public submitted: boolean;

    constructor(private userService: UserService) { }

    ngOnInit(): void {
        this.firstName = "";
        this.lastName = "";
        this.username = "";
        this.password = "";
        this.submitted = false;
    }


    public registerUser() {
        this.submitted = true;
        this.userService.registerUser(this.firstName, this.lastName, this.username, this.password).subscribe(it => {
        })
    }
}

