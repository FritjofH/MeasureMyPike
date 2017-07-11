import { Component, OnInit } from '@angular/core';
import { BrandService } from '../../service/brand/brand.service';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-brand-view',
  templateUrl: './brand-view.component.html',
  styleUrls: ['./brand-view.component.scss']
})

export class BrandViewComponent implements OnInit {

    constructor(private brandService: BrandService) { }

    public brandList: any[];
    public selectedBrand: any;
    public newName: string;
timerSubscription: any;

    ngOnInit() {
        this.getBrands();
    }

ngOnDestroy(): void {
    if (this.timerSubscription) {
        this.timerSubscription.unsubscribe();
    }
}

    public getBrands() {
        this.brandService.getBrands().subscribe(it => {
            this.brandList = it;
            this.subscribeToData();
        })
    };

    private subscribeToData(): void {
        this.timerSubscription = Observable.timer(5000).first().subscribe(() => this.getBrands());
    }

    public getBrand(selected) {
        if (this.selectedBrand && selected.id == this.selectedBrand.id) {
            this.selectedBrand = null;
        }
        else {
            this.selectedBrand = selected;
            this.newName = null;
        }
    }

    public updateBrand() {
        this.brandService.updateBrand(this.selectedBrand.id, this.newName).subscribe(it => {
            this.selectedBrand = it;
            this.getBrands();
            this.newName = null;
            this.selectedBrand = null;
        })
    }
}
