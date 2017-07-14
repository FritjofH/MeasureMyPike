import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Http, Response, URLSearchParams } from '@angular/http';
import { JwtHelper, AuthHttp } from 'angular2-jwt';

@Injectable()
export class StatisticsService {

    constructor(private http: Http, private authHttp: AuthHttp) {
    }

    public getCatchForUser(username: string, startDate: string): Observable<any> {
        return this.http.get("api/Statistics/perUser?username=" + username + "&startDate=" + startDate)
            .map(this.extractData)
            .catch(this.handleError);
    }

    public getCatchesForLake(lakeName: string, startDate: string): Observable<any> {
        return this.http.get("api/Statistics/perLake?lakename=" + lakeName + "&startDate=" + startDate)
            .map(this.extractData)
            .catch(this.handleError);
    }

    public getMostPopularLake(username: string): Observable<any> {
        return this.http.get("api/Statistics/topLake?startDate=" + username)
            .map(this.extractData)
            .catch(this.handleError);
    }

    public getBiggestFish(noOfCatches: number, startDate: string): Observable<any> {
        return this.http.get("api/Statistics/topFish?catches=" + noOfCatches +  "&startDate=" + startDate)
            .map(this.extractData)
            .catch(this.handleError);
    }

    public getLatestCatch(noOfCatches: number): Observable<any> {
        return this.http.get("api/Statistics/latestCatch?catches=" + noOfCatches)
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
