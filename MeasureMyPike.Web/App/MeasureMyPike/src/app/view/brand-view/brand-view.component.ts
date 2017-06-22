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

    public newName: string;

    ngOnInit() {
        this.getBrands();
    }

    public getBrands() {
        this.brandService.getBrands().subscribe(it => {
            this.brandList = it;
        })
    };

    public getBrand(selected) {

        if (this.selectedBrand && selected.id == this.selectedBrand.id) {
            this.selectedBrand = null;
        }
        else {
            this.selectedBrand = selected;
            this.newName = null;
        }

        //this.selectedBrand.emit(this.selectedBrand);
    }

    public updateBrand() {
        this.brandService.updateBrand(this.selectedBrand.id, this.newName).subscribe(it => {
            this.selectedBrand = it;
            this.getBrands();
            this.newName = null;
        })
    }
}
