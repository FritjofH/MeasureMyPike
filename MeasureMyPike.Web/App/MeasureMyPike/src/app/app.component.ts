import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-root',
  templateUrl: 'app.component.html',
  styleUrls: ['app.component.scss']
})

export class AppComponent {

    public title = 'MeasureMyPike';

    constructor(public router: Router) {
    }

    logout() {
        localStorage.removeItem('id_token');
        this.router.navigate(['login']);
    }
}
