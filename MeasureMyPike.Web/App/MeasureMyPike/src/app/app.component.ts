import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: 'app.component.html',
  styleUrls: ['app.component.scss']
})

export class AppComponent {

    public title = 'MeasureMyPike';
    public loggedIn: boolean = true;
    public brandViewVisible: boolean = false;
    public userViewVisible: boolean = false;
    public catchViewVisible: boolean = false;

    constructor() {
    }

    public logout() {
        this.hideAll();
        this.loggedIn = false;
    }

    private hideAll() {
        this.brandViewVisible = false;
        this.catchViewVisible = false;
        this.userViewVisible = false;
    }
}
