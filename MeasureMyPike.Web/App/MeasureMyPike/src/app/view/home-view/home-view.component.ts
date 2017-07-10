import { Component } from '@angular/core';
import { HomeService } from '../../service/home/home.service';
import { Sort } from '@angular/material';

@Component({
    selector: 'app-home-view',
    templateUrl: './home-view.component.html',
    styleUrls: ['./home-view.component.scss']
})

export class HomeViewComponent {


    biggestFishList: any[] = [
        { weight: '12', length: '55', lake: 'Storsjön', user: 'nilspelle', date: '2017-06-21' },
        { weight: '17', length: '90', lake: 'Käppesjön', user: 'chilimannen', date: '2017-06-22' },
        { weight: '5', length: '30', lake: 'Mälaren', user: 'johhny2d', date: '2017-06-23' },
        { weight: '40', length: '150', lake: 'Östersjön', user: 'hostf', date: '2017-07-02' },
        { weight: '22', length: '110', lake: 'Vänern', user: 'johhny2d', date: '2017-05-01' }
    ];
    popularLakeList: any[] = [
        {lake: 'Vänern', noCatches: '22', uniqueUsers: '4'},
        {lake: 'Käppesjön', noCatches: '33', uniqueUsers: '1'},
        {lake: 'Mälaren', noCatches: '11', uniqueUsers: '3'},
        {lake: 'Östersjön', noCatches: '44', uniqueUsers: '12'},
        {lake: 'Storsjön', noCatches: '55', uniqueUsers: '21'}
    ];

    latestFishList: any[] = [
        { weight: '12', length: '55', lake: 'Storsjön', user: 'nilspelle', date: '2017-06-21' },
        { weight: '17', length: '90', lake: 'Käppesjön', user: 'chilimannen', date: '2017-06-22' },
        { weight: '5', length: '30', lake: 'Mälaren', user: 'johhny2d', date: '2017-06-23' },
        { weight: '40', length: '150', lake: 'Östersjön', user: 'hostf', date: '2017-07-02' },
        { weight: '22', length: '110', lake: 'Vänern', user: 'johhny2d', date: '2017-05-01' }
    ];

    constructor(private homeService: HomeService) { 
    }

    sortFish(sort: Sort) {
        const data = this.biggestFishList.slice();
        if (!sort.active || sort.direction == '') {
            this.biggestFishList = data;
            return;
        }

        this.biggestFishList = data.sort((a, b) => {
            let isAsc = sort.direction == 'asc';
            switch (sort.active) {
                case 'weight': return compare(+a.weight, +b.weight, isAsc);
                case 'length': return compare(+a.length, +b.length, isAsc);
                case 'lake': return compare(a.lake, b.lake, isAsc);
                case 'user': return compare(a.user, b.user, isAsc);
case 'date': return compare(a.date, b.date, isAsc);
                default: return 0;
            }
        });
    }

    sortPopularLakeData(sort: Sort) {
        const data = this.popularLakeList.slice();
        if (!sort.active || sort.direction == '') {
            this.popularLakeList = data;
            return;
        }

        this.popularLakeList = data.sort((a, b) => {
            let isAsc = sort.direction == 'asc';
            switch (sort.active) {
                case 'lake': return compare(a.lake, b.lake, isAsc);
                case 'noCatches': return compare(+a.noCatches, +b.noCatches, isAsc);
                case 'uniqueUsers': return compare(+a.uniqueUsers, +b.uniqueUsers, isAsc);
                default: return 0;
            }
        });
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

function compare(a, b, isAsc) {
    return (a < b ? -1 : 1) * (isAsc ? 1 : -1);
}



