import { Component } from '@angular/core';
import { MdDialog, MdDialogRef } from '@angular/material';
import { UserService } from '../../service/user/user.service';
import { Injectable } from '@angular/core';

@Component({
    selector: 'logout-dialog',
    templateUrl: './logoutDialog.component.html',
    styleUrls: ['./logoutDialog.component.scss']
})
export class LogoutDialogComponent {

    public selectedOption: boolean;
    public dialogRef: MdDialogRef<LogoutDialogComponent>

    constructor(public dialog: MdDialog, public userService: UserService) {
    }

    public openDialog() {
        this.dialogRef = this.dialog.open(LogoutDialogComponent);

        this.dialogRef.afterClosed().subscribe((result: boolean) => {
            this.selectedOption = result;

            if (this.selectedOption == true) {
                this.selectedOption == null;
                this.userService.logout();
            }
        });

    }
}