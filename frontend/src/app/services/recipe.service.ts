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

   getRecipesOfCollection(collectionId: string){
    return this.http.get(this.baseUrl + `/Reteta/allFromCollection/${collectionId}`, this.headers);
  }
}
