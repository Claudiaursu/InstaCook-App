import { HttpClient, HttpHandler, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private baseUrl : string = environment.baseUrl;
  private publicHeaders = {
    headers: new HttpHeaders({
      'content-type': 'application/json',
      'accept': '*/*',
      'Access-Control-Allow-Origin': 'http://localhost:4200'
    }),
  }

  constructor(private http: HttpClient) {
   }

   login(data: any){
    const authPath = '/Utilizator/authenticate';
    return this.http.post(
      this.baseUrl + authPath,
      data,
      this.publicHeaders)
   }
}
