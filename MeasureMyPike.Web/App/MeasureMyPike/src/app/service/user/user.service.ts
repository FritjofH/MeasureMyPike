import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Http, Response, URLSearchParams } from '@angular/http';
import { tokenNotExpired } from 'angular2-jwt';
import { contentHeaders } from '../../common/headers';
import { Router } from '@angular/router';
import { JwtHelper } from 'angular2-jwt';

@Injectable()
export class UserService {
    jwt: string;
    decodedJwt: string;
    response: string;
    api: string;
    jwtHelper: JwtHelper = new JwtHelper();
    jwtExpired: any;
    jwtDate: any;

    constructor(private http: Http, public router: Router, ) {
        this.jwt = localStorage.getItem('token');

        this.decodedJwt = this.jwtHelper.decodeToken(this.jwt);
        this.jwtDate = this.jwtHelper.getTokenExpirationDate(this.jwt);
        this.jwtExpired = this.jwtHelper.isTokenExpired(this.jwt);
    }

    public getUser(username: string): Observable<any> {
        return this.http.get("/api/User?username=" + username)
            .map(this.extractData)
            .catch(this.handleError);
    }

    public decodeUserToken(token: string) {
        var parsedToken = this.jwtHelper.decodeToken(token);
        

        return parsedToken.unique_name;
    }

    public login(username: string, password: string) {
        this.http.post('/api/Security', { "username": username, "password": password }, { headers: contentHeaders })
            .subscribe(
            response => {
                localStorage.setItem('token', response.headers.get('token'));
                this.router.navigate(['home']);
            },
            error => {
                alert(error.text());
                console.log(error.text());
            }
            );
    }

    public registerUser(lastName: string, firstName: string, username: string, password: string): Observable<any> {
        return this.http.post("/api/User", { "lastName": lastName, "firstName": firstName, "username": username, "password": password })
            .map(this.extractData)
            .catch(this.handleError);
    }

    public loggedIn() {
        return tokenNotExpired();
    }

    public logout() {
        localStorage.removeItem('token');
        this.router.navigate(['home']);
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
