import { Component, OnInit } from '@angular/core';
import { FishService } from '../../service/fish.service';

@Component({
  selector: 'app-fish-view',
  templateUrl: './fish-view.component.html',
  styleUrls: ['./fish-view.component.css']
})
export class FishViewComponent implements OnInit {

    constructor(private fishService: FishService) { }

    public fishes: any[];

    ngOnInit() {
        this.fishService.getFishes().subscribe(it => {
            this.fishes = it;
        });
  }

}
