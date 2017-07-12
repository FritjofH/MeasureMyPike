import { Component, OnInit } from '@angular/core';
import { UserService } from '../../../service/user/user.service';
import { SaveChangesDialogComponent } from '../../../common/saveChanges/saveChangesDialog.component';
import { Router } from '@angular/router';

@Component({
    selector: 'app-user-view',
    templateUrl: './userProfile-view.component.html',
    styleUrls: ['./userProfile-view.component.scss'],
    providers: [SaveChangesDialogComponent]
})

export class UserProfileViewComponent implements OnInit {
    public username: string;
    public memberSince: string;
    private initialFirstName: string;
    private initialLastName: string;
    public newFirstName: string;
    public newLastName: string;
    public edit: boolean = false;

    constructor(private userService: UserService, private saveChangesDialog: SaveChangesDialogComponent, private router: Router) {
    }

    ngOnInit(): void {
        this.username = this.router.url.substring(this.router.url.lastIndexOf('/') + 1);
        this.getUser();
    }

    private getUser() {
        this.userService.getUser(this.username).subscribe(it => {
            this.memberSince = it.memberSince;
            this.newFirstName = it.firstname;
            this.initialFirstName = it.firstname;
            this.newLastName = it.lastname;
            this.initialLastName = it.lastname;
        })
    };

    public updateName(firstName: string, lastName: string, username: string) {
        if (firstName == this.initialFirstName && lastName == this.initialLastName) {
            this.setEdit();
        } else {
            this.saveChangesDialog.openDialog().subscribe((confirmation) => {
                if (confirmation == true) {
                    this.userService.updateUser(firstName, lastName, username);

                    this.initialFirstName = this.newFirstName;
                    this.initialLastName = this.newLastName;

                    this.setEdit();
                }
            });
        }
    }

    private setEdit() {
        if (this.edit == false) {
            this.edit = true;
        } else {
            this.edit = false;
        }
    }
}

