import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Colectie } from '../interfaces/colectie';

@Injectable({
  providedIn: 'root'
})
export class CollectionService {
  private baseUrl = environment.baseUrl;
  private headers = {
    headers: new HttpHeaders({
      'content-type': 'application/json',
      'accept': '*/*',
    })
  };

  constructor(private http: HttpClient) {

   }

   createNewColection(userId: string, newCollection: Colectie){
    const url = this.baseUrl + `/Colectie/${userId}`;
    return this.http.post(url , newCollection, this.headers);
   }

   getAllColectii(userId: string){
    const url = this.baseUrl + `/Colectie/getAllForUser/${userId}`;
    return this.http.get<any[]>(url, this.headers);
   }

   deleteColectie(titlu: string){
     console.log("titlu venit ", titlu)
    const url = this.baseUrl + `/Colectie/deleteByTitle${titlu}`;
    return this.http.delete(url, this.headers);
   }
}
