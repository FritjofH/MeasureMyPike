import { Component, OnInit } from '@angular/core';
import { SaveChangesDialogComponent, UtilService } from '../../../common/index';
import { Router } from '@angular/router';
import { Sort } from '@angular/material';
import { StatisticsService } from '../../../service/statistics/statistics.service';
import { User, UserService } from '../../../model/user/user';

@Component({
    selector: 'app-user-view',
    templateUrl: './userProfile-view.component.html',
    styleUrls: ['./userProfile-view.component.scss'],
    providers: [SaveChangesDialogComponent, UtilService, StatisticsService]
})

export class UserProfileViewComponent implements OnInit {
    public user: User = {
        firstName: "",
        lastName: "",
        username: "",
        password: "",
        memberSince: ""
    };
    private initialFirstName: string;
    private initialLastName: string;
    public edit: boolean = false;
    public currentUser: boolean = false;
    public userCatchList: any[];
    public fishShown: boolean = false;
    public tackleBoxShown: boolean = false;
    public tackleBox: any[];

    constructor(private userService: UserService, private saveChangesDialog: SaveChangesDialogComponent, private router: Router, private utilService: UtilService, private statisticsService: StatisticsService) {
    }

    ngOnInit(): void {
        this.user.username = this.router.url.substring(this.router.url.lastIndexOf('/') + 1);
        this.checkCurrentUser();
        this.getUser();
        this.getUserCatch(this.user.username, '2017-01-01');
        this.getUserTackleBox(this.user.username);
    }
    
    private getUserCatch(username: string, startDate: string) {
        this.statisticsService.getCatchForUser(username, startDate).subscribe(it => {
            this.userCatchList = it;
        })
    };

    private getUserTackleBox(username: string) {
        this.userService.getTackleBoxForUser(username).subscribe(it => {
            this.tackleBox = it;
        })
    };

    private checkCurrentUser(){
        var currentUsername = this.userService.decodeUserToken(localStorage.getItem('token'));

        if(currentUsername == this.user.username){
            this.currentUser = true;
        }
    }

    private getUser() {
        this.userService.getUser(this.user.username).subscribe(it => {
            this.user.memberSince = it.memberSince;
            this.user.firstName = it.firstname;
            this.initialFirstName = it.firstname;
            this.user.lastName = it.lastname;
            this.initialLastName = it.lastname;
        })
    };

    public updateName() {
        if (this.user.firstName == this.initialFirstName && this.user.lastName == this.initialLastName) {
            this.setEdit();
        } else {
            this.saveChangesDialog.openDialog().subscribe((confirmation) => {
                if (confirmation == true) {
                    this.userService.updateUser(this.user);

                    this.initialFirstName = this.user.firstName;
                    this.initialLastName = this.user.lastName;

                    this.setEdit();
                }
            });
        }
    }

    public sortCatch(sort: Sort){
        const data = this.userCatchList.slice();
        if (!sort.active || sort.direction == '') {
            this.userCatchList = data;
            return;
        }

        this.userCatchList = data.sort((a, b) => {
            let isAsc = sort.direction == 'asc';
            switch (sort.active) {
                case 'weight': return this.utilService.compare(+a.weight, +b.weight, isAsc);
                case 'length': return this.utilService.compare(+a.length, +b.length, isAsc);
                case 'lake': return this.utilService.compare(a.lake, b.lake, isAsc);
                case 'user': return this.utilService.compare(a.user, b.user, isAsc);
                case 'date': return this.utilService.compare(a.date, b.date, isAsc);
                default: return 0;
            }
        });
    }

    public sortTackleBox(sort: Sort){
        const data = this.tackleBox.slice();
        if (!sort.active || sort.direction == '') {
            this.tackleBox = data;
            return;
        }

        this.tackleBox = data.sort((a, b) => {
            let isAsc = sort.direction == 'asc';
            switch (sort.active) {
                case 'lureName': return this.utilService.compare(a.lureName, b.lureName, isAsc);
                case 'lureWeight': return this.utilService.compare(+a.lureWeight, +b.lureWeight, isAsc);
                case 'lureColour': return this.utilService.compare(a.lureColour, b.lureColour, isAsc);
                case 'lureBrand': return this.utilService.compare(a.lureBrand, b.lureBrand, isAsc);
                default: return 0;
            }
        });
    }
    
    private toggleTackleBox() {
        if (this.tackleBoxShown == false) {
            this.tackleBoxShown = true;
        } else {
            this.tackleBoxShown = false;
        }
    }

    private toggleFish() {
        if (this.fishShown == false) {
            this.fishShown = true;
        } else {
            this.fishShown = false;
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

