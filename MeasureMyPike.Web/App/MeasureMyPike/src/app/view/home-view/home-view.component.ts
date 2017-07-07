import { Component, OnInit } from '@angular/core';
import { HomeService } from '../../service/home/home.service';

@Component({
    selector: 'app-home-view',
    templateUrl: './home-view.component.html',
    styleUrls: ['./home-view.component.scss']
})

export class HomeViewComponent implements OnInit {

    constructor(private homeService: HomeService) { }

    public biggestFishList: any[];
    public latestFishList: any[];
    public popularLakeList: any[];

    ngOnInit() {
    }

    public getBiggestFish() {
        this.homeService.getBiggestFish().subscribe(it => {
            this.biggestFishList = it;
        })

    };

    public getLatestFish() {
        this.homeService.getLatestFish().subscribe(it => {
            this.latestFishList = it;
        })
    };

    public getPopularLake() {
        this.homeService.getPopularLake().subscribe(it => {
            this.popularLakeList = it;
        })
    };


}
