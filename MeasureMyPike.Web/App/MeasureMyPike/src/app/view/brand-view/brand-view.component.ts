import { Component, OnInit } from '@angular/core';
import { BrandService } from '../../service/brand/brand.service';

@Component({
  selector: 'app-brand-view',
  templateUrl: './brand-view.component.html',
  styleUrls: ['./brand-view.component.scss']
})
export class BrandViewComponent implements OnInit {

    constructor(private brandService: BrandService) { }

    public brandList: any[];

    public selectedBrand: any;

    ngOnInit() {
        this.brandService.getBrands().subscribe(it => {
            this.brandList = it;
        });
    }

    private onRowClicked(item) {
        this.brandService.getBrand(item.id).subscribe(it => {
            this.selectedBrand = it
        });
    }

}
