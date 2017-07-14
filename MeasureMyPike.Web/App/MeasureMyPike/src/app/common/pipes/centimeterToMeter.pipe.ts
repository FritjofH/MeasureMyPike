import {Pipe} from '@angular/core';

@Pipe({
	name : "toMeter"
})
 
export class CentimeterToMeter{
	transform(value){
		return value/100;
	}
}