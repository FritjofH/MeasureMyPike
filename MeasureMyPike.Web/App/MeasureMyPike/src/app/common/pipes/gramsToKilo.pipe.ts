import {Pipe} from '@angular/core';

@Pipe({
	name : "toKilos"
})
 
export class GramsToKilos{
	transform(value){
		return value/1000;
	}
}