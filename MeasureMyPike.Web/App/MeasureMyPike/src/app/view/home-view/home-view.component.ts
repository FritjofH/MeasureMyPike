import { Component, OnInit } from '@angular/core';
import { HomeService } from '../../service/home/home.service';

@Component({
  selector: 'app-home-view',
  templateUrl: './home-view.component.html',
  styleUrls: ['./home-view.component.scss']
})

export class HomeViewComponent implements OnInit {

    constructor(private homeService: HomeService) { }

    public brandList: any[];
    public selectedBrand: any;
    public newName: string;

    ngOnInit() {
       
    }

}
