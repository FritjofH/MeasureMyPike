import { Component, OnInit } from '@angular/core';
import { UserService } from '../../../service/user/user.service';

@Component({
    selector: 'app-user-view',
    templateUrl: './userProfile-view.component.html',
    styleUrls: ['./userProfile-view.component.scss']
})

export class UserProfileViewComponent implements OnInit {
    userName: string;

    constructor(private userService: UserService) {
    }

    ngOnInit(): void {
    }
}

