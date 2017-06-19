import { Component, OnInit } from '@angular/core';
import { BrandService } from '../../service/brand/brand.service';

@Component({
  selector: 'app-brand-view',
  templateUrl: './brand-view.component.html',
  styleUrls: ['./brand-view.component.css']
})
export class BrandViewComponent implements OnInit {

    constructor(private brandService: BrandService) { }

    public brands: any[];

    ngOnInit() {
        this.brandService.getBrands().subscribe(it => {
            this.brands = it;
        });
  }

}
