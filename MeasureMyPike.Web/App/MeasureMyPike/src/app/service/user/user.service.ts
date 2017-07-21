import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Http, Response, URLSearchParams } from '@angular/http';
import { tokenNotExpired } from 'angular2-jwt';
import { contentHeaders } from '../../common/headers';
import { Router } from '@angular/router';
import { JwtHelper, AuthHttp } from 'angular2-jwt';
import { User } from '../../model/user/user';

@Injectable()
export class UserService {
    private jwtHelper: JwtHelper = new JwtHelper();

    constructor(private http: Http, private router: Router, private authHttp: AuthHttp) {    }

    public getUser(username: string): Observable<any> {
        return this.http.get("api/User?username=" + username)
            .map(this.extractData)
            .catch(this.handleError);
    }

    public getTackleBoxForUser(username: string): Observable<any> {
        return this.http.get("api/User/GetTackleBoxForUser?username=" + username)
            .map(this.extractData)
            .catch(this.handleError);
    }

    public updateUser(user: User) {
        this.authHttp.put('api/User', user)
            .subscribe(
            response => {            },
            error => {
                alert(error.text());
                console.log(error.text());
            }
            );
    }

    public login(user: User) {
        this.http.post('api/Security', user, { headers: contentHeaders })
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

    public registerUser(user: User): Observable<any> {
        return this.http.post("api/User", user)
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

    public decodeUserToken(token: string) {
        var parsedToken = this.jwtHelper.decodeToken(token);

        return parsedToken.unique_name;
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
