import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';


@Injectable({ providedIn: 'root' })
export class ConstantsService {

    private _issend: boolean;
    private _data: any;

    get constrants(): any {
        if(!this._issend) {
            this._issend = true;
            this.http.get('/assets/api/constants.json').subscribe(data => this._data = data);
        }
        return this._data;
    }

    constructor(private http: HttpClient) {}
}