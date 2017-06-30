﻿import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Http, Response } from '@angular/http';

@Injectable()
export class UserService {

    constructor(private http: Http) { }

    getUsers(): Observable<any[]> {
        return this.http.get("/api/User")
            .map(this.extractData)
            .catch(this.handleError);
    }

    getUser(int: number): Observable<any> {
        return this.http.get("/api/User")
            .map(this.extractData)
            .catch(this.handleError);
    }

    loginUser(username: string, password: string): Observable<any> {
        //TODO login med lösenord
        //komplexa objekt i gets fungerar inte?
        return this.http.get("/api/User/" + username)
            .map(this.extractData)
            .catch(this.handleError);
    }

    registerUser(lastName: string, firstName: string, username: string, password: string): Observable<any> {
        return this.http.post("/api/User", {"lastName": lastName, "firstName": firstName, "username": username, "password": password })
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
