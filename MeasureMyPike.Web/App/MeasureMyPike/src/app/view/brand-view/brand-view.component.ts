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

    public selectBrand(selected) {

        if (this.selectedBrand && selected.id == this.selectedBrand.id) {
            this.selectedBrand = null;
        }
        else {
            this.selectedBrand = selected;
        }

        //this.selectedBrand.emit(this.selectedBrand);
    }

}
