import { Component } from '@angular/core';
import { UserService } from '../../service/user/user.service';

@Component({
    selector: 'app-user-view',
    templateUrl: './user-view.component.html',
    styleUrls: ['./user-view.component.scss']
})
export class UserViewComponent {

    constructor(private userService: UserService) { }

    public firstName: string ="";
    public lastName: string ="";
    public username: string ="";
    public password: string ="";
    public submitted: boolean = false;

    public registerUser() {
        this.submitted = true;
        this.userService.registerUser(this.firstName, this.lastName, this.username, this.password).subscribe(it => {
        })
    }
}

