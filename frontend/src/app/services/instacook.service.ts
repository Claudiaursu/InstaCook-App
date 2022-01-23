import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Colectie } from '../interfaces/colectie';

@Injectable({
  providedIn: 'root'
})
export class InstaCookService {
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

   createNewColection(userId: string, newCollection: Colectie){
    const url = this.baseUrl + `/Colectie/${userId}`;
    return this.http.post(url , newCollection, this.headers);
   }
}
