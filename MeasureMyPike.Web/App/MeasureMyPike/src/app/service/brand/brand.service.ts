import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Http, Response } from '@angular/http';

@Injectable()
export class BrandService {

    constructor(private http: Http) { }

    getBrands(): Observable<any[]> {
        return this.http.get("/api/Brand")
            .map(this.extractData)
            .catch(this.handleError);
    }

    getBrand(int: number): Observable<any[]> {
            return this.http.get("/api/Brand")
                .map(this.extractData)
                .catch(this.handleError);
    }

    updateBrand(id: number, name: string): Observable<any[]> {
        return this.http.put("/api/Brand", { "id": id, "name": name })
            .map(this.extractData)
            .catch(this.handleError);
    }

    private extractData(res: Response) {
        let body = res.json();
        return body || {};
    }

    private handleError(error: Response | any) {
        // In a real world app, you might use a remote logging infrastructure
        let errMsg: string;
        if (error instanceof Response) {
            const body = error.json() || '';
            const err = body.error || JSON.stringify(body);
            errMsg = `${error.status} - ${error.statusText || ''} ${err}`;
        } else {
            errMsg = error.message ? error.message : error.toString();
        }
        console.error(errMsg);
        return Observable.throw(errMsg);
    }
}
