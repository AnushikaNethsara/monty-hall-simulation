import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { APIUrl } from 'src/constants/constants';

@Injectable({
  providedIn: 'root',
})
export class SharedService {
  constructor(private http: HttpClient) {}

  runSimulation(data: object) {
    return this.http.post(APIUrl + '/simulation', data);
  }
}
