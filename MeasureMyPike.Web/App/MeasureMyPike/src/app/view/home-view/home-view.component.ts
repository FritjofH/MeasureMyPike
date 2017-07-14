import { Component, OnInit } from '@angular/core';
import { HomeService } from '../../service/home/home.service';
import { StatisticsService } from '../../service/statistics/statistics.service';
import { Sort } from '@angular/material';
import { Router } from '@angular/router';
import { UtilService } from '../../common/util.service';
import { Observable } from 'rxjs';
import { GramsToKilos } from '../../common/pipes/gramsToKilo.pipe';
import { CentimeterToMeter } from '../../common/pipes/centimeterToMeter.pipe';

@Component({
    selector: 'app-home-view',
    templateUrl: './home-view.component.html',
    styleUrls: ['./home-view.component.scss'],
    providers: [UtilService, StatisticsService]
})

export class HomeViewComponent implements OnInit {
    public biggestFishList: any[];
    public popularLakeList: any[];
    public latestFishList: any[];
    private timerSubscription: any;
    private sort: Sort;

    constructor(private homeService: HomeService, private router: Router, private utilService: UtilService, private statisticsService: StatisticsService) {
    }

    ngOnInit() {
        this.getBiggestFish(5, '2017-01-01');
        this.getLatestFish(5);
        this.getPopularLake('2017-01-01');
    }

    private ngOnDestroy(): void {
        if (this.timerSubscription) {
            this.timerSubscription.unsubscribe();
        }
    }

    public getBiggestFish(noOfCatches: number, startDate: string) {
        this.statisticsService.getBiggestFish(noOfCatches, startDate).subscribe(it => {
            this.biggestFishList = it;
        })
    };

    public getLatestFish(noOfCatches: number) {
        this.statisticsService.getLatestCatch(noOfCatches).subscribe(it => {
            this.latestFishList = it;
            this.subscribeToData(noOfCatches);
            if(this.sort != null){
                this.sortLatestFish(this.sort);
            }
            
        })
    };

    public getPopularLake(startDate: string) {
        this.statisticsService.getMostPopularLake(startDate).subscribe(it => {
            this.popularLakeList = it;
        })
    };

    private subscribeToData(noOfCatches: number): void {
        this.timerSubscription = Observable.timer(5000).first().subscribe(() => this.getLatestFish(noOfCatches));
    }

    public sortBiggestFish(sort: Sort) {
        const data = this.biggestFishList.slice();
        if (!sort.active || sort.direction == '') {
            this.biggestFishList = data;
            return;
        }

        this.biggestFishList = data.sort((a, b) => {
            let isAsc = sort.direction == 'asc';
            switch (sort.active) {
                case 'fishWeight': return this.utilService.compare(+a.fishWeight, +b.fishWeight, isAsc);
                case 'fishLength': return this.utilService.compare(+a.fishLength, +b.fishLength, isAsc);
                case 'lakeName': return this.utilService.compare(a.lakeName, b.lakeName, isAsc);
                case 'userName': return this.utilService.compare(a.userName, b.userName, isAsc);
                case 'timestamp': return this.utilService.compare(a.timestamp, b.timestamp, isAsc);
                default: return 0;
            }
        });
    }

    public sortLatestFish(sort: Sort) {
        this.sort = sort;
        const data = this.latestFishList.slice();
        if (!sort.active || sort.direction == '') {
            this.latestFishList = data;
            return;
        }

        this.latestFishList = data.sort((a, b) => {
            let isAsc = sort.direction == 'asc';
            switch (sort.active) {
                case 'fishWeight': return this.utilService.compare(+a.fishWeight, +b.fishWeight, isAsc);
                case 'fishLength': return this.utilService.compare(+a.fishLength, +b.fishLength, isAsc);
                case 'lakeName': return this.utilService.compare(a.lakeName, b.lakeName, isAsc);
                case 'userName': return this.utilService.compare(a.userName, b.userName, isAsc);
                case 'timestamp': return this.utilService.compare(a.timestamp, b.timestamp, isAsc);
                default: return 0;
            }
        });
    }

    public sortPopularLakeData(sort: Sort) {
        const data = this.popularLakeList.slice();
        if (!sort.active || sort.direction == '') {
            this.popularLakeList = data;
            return;
        }

        this.popularLakeList = data.sort((a, b) => {
            let isAsc = sort.direction == 'asc';
            switch (sort.active) {
                case 'lakeName': return this.utilService.compare(a.lakeName, b.lakeName, isAsc);
                case 'catchId.length': return this.utilService.compare(+a.catchId.length, +b.catchId.length, isAsc);
                case 'totalFishLength': return this.utilService.compare(+a.totalFishLength, +b.totalFishLength, isAsc);
                case 'totalFishWeight': return this.utilService.compare(+a.totalFishWeight, +b.totalFishWeight, isAsc);
                default: return 0;
            }
        });
    }

    public navigateToUser(currentUsername: string) {
        this.router.navigate(['/user/' + currentUsername]);
    }
}