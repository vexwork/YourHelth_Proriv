import { Injectable } from '@angular/core';
import {HttpClient } from '@angular/common/http';
import { AppSettings } from './appsettings';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class UserService {

    constructor( public httpClient: HttpClient ) { }

    public findUsers(postData){
      return this.httpClient.post<any[]>(AppSettings.API_URL + "/search-patients", postData);
    }

    public sendReception(postData){
      return this.httpClient.post<any[]>(AppSettings.API_URL + "/reception", postData);
    }

    public sendTherapy(postData){
        return this.httpClient.post<any[]>(AppSettings.API_URL + "/therapy", postData);
    }
}
