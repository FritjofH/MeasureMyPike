import { Injectable, Component } from '@angular/core';
import { Observable } from 'rxjs';
import { Http, Response } from '@angular/http';
import { AuthHttp, JwtHelper } from 'angular2-jwt';
import { Router } from '@angular/router';

@Injectable()
export class BrandService {

    jwt: string;
    decodedJwt: string;
    response: string;
    api: string;
    jwtHelper: JwtHelper = new JwtHelper();
    jwtExpired: any;
    jwtDate: any;

    constructor(public router: Router, public http: Http, public authHttp: AuthHttp) {
        this.jwt = sessionStorage.getItem('token');

        this.decodedJwt = this.jwtHelper.decodeToken(this.jwt);
        this.jwtDate = this.jwtHelper.getTokenExpirationDate(this.jwt);
        this.jwtExpired = this.jwtHelper.isTokenExpired(this.jwt);
    }

    getBrands(): Observable<any[]> {
        return this.authHttp.get("/api/Brand")
            .map(this.extractData)
            .catch(this.handleError);
    }

    getBrand(int: number): Observable<any[]> {
        return this.authHttp.get("/api/Brand")
                .map(this.extractData)
                .catch(this.handleError);
    }

    updateBrand(id: number, name: string): Observable<any[]> {
        return this.authHttp.put("/api/Brand", { "id": id, "name": name })
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
