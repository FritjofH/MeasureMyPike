import { Component } from '@angular/core';
import { Catch, CatchService } from '../../model/catch/catch';
import { FormControl } from '@angular/forms';
import 'rxjs/add/operator/startWith';
import 'rxjs/add/operator/map';

@Component({
    selector: 'catch-home-view',
    templateUrl: './catch-view.component.html',
    styleUrls: ['./catch-view.component.scss']
})

export class CatchViewComponent {
    private newCatch: Catch = {
        weight: 0,
        length: 0,
        date: new Date().toISOString().slice(0, 16),
        lakeName: "",
        lureName: "",
        weather: "",
        comment: "",
        coordinates: "",
        airTemp: 0,
        waterTemp: 0,
        username: "",
        imageData: ""
    };
    private showOptional: boolean = true;
    myControl: FormControl;
    option = ['one', 'two', 'three']
    filteredOptions: any;

    constructor(private catchService: CatchService) {
        this.myControl = new FormControl();
        this.filteredOptions = this.myControl.valueChanges
            .startWith(null)
            .map(name => this.filter(name));
    }

    filter(val: string) {
    return val ? this.option.filter(s => s.toLowerCase().indexOf(val.toLowerCase()) === 0)
               : this.option;
  }

    public RegisterNewCatch() {
        this.catchService.RegisterCatch(this.newCatch);
    }

    private toggleOptional() {
        if (this.showOptional == false) {
            this.showOptional = true;
        } else {
            this.showOptional = false;
        }
    }
}