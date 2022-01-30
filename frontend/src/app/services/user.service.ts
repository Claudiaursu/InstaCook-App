import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  private baseUrl = environment.baseUrl;
  private headers = {
    headers: new HttpHeaders({
      'content-type': 'application/json',
      'accept': '*/*',
    })
  };

  constructor(private http: HttpClient) {

   }

   getUserInfoById(id: string){
     return this.http.get(this.baseUrl + `/Utilizator/getById/${id}`, this.headers);
   }

   getUsers(){
    return this.http.get(this.baseUrl + '/Utilizator/getAll', this.headers);
  }
}
