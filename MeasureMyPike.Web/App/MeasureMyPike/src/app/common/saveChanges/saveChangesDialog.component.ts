import { Component } from '@angular/core';
import { MdDialog, MdDialogRef } from '@angular/material';
import { UserService } from '../../service/user/user.service';
import { Injectable } from '@angular/core';
import { Observable, Observer } from 'rxjs';

@Component({
    selector: 'saveChanges-dialog',
    templateUrl: './saveChangesDialog.component.html',
    styleUrls: ['./saveChangesDialog.component.scss']
})
export class SaveChangesDialogComponent {

    public selectedOption: boolean;
    public dialogRef: MdDialogRef<SaveChangesDialogComponent>

    constructor(public dialog: MdDialog, public userService: UserService) {
    }

    public openDialog() : Observable<boolean>{
        this.dialogRef = this.dialog.open(SaveChangesDialogComponent);
        return Observable.create((obs: Observer<boolean>) => {
            this.dialogRef.afterClosed().subscribe((result: boolean) => {
                this.selectedOption = result;

                if (this.selectedOption == true) {
                    this.selectedOption == null;
                    obs.next(true);
                    obs.complete();
                }
                obs.next(false);
                obs.complete();
            });
        });
    }

}