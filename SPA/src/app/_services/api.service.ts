import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';
import { ICheck } from '../_models/ICheck';

@Injectable({
  providedIn: 'root'
})
export class ApiService {

  baseUrl = environment.apiUrl + '/check';

  constructor(private http: HttpClient) { }

  submitCheck(check: ICheck) {

    return this.http.post(this.baseUrl, check);

  }

}
