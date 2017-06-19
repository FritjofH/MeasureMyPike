import { Component, OnInit } from '@angular/core';
import { UserService } from '../../service/user/user.service';

@Component({
  selector: 'app-user-view',
  templateUrl: './user-view.component.html',
  styleUrls: ['./user-view.component.css']
})
export class UserViewComponent implements OnInit {

    constructor(private brandService: UserService) { }

    public brands: any[];

    ngOnInit() {
        this.brandService.getUsers().subscribe(it => {
            this.brands = it;
        });
  }

}
