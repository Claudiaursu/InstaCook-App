import { Component, Input, OnInit } from '@angular/core';
import { MatSlideToggleChange } from '@angular/material/slide-toggle';
import { ActivatedRoute } from '@angular/router';
import { Colectie } from 'src/app/interfaces/colectie';
import { InstaCookService } from 'src/app/services/instacook.service';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css']
})
export class ProfileComponent implements OnInit {

  loggedUser: any = null;
  colectiiUser: any[] = [];
  showPrivateCollections: boolean = false;
  filterSweets: boolean = false;

  constructor(
    private activatedRoute: ActivatedRoute,
    private instaCookService: InstaCookService
    ) { }

  ngOnInit(): void {
    this.getLoggedUserInfo();
    this.getColectiiForUser();
    console.log("colectii pag profil: ", this.colectiiUser)
  }

  getLoggedUserInfo(){
    this.activatedRoute.params.subscribe((params: any) => {
      console.log(params)
      this.loggedUser = {
        id: params['id'],
        username: localStorage.getItem('loggedUsername'),
        token: localStorage.getItem('token')
      }
      console.log("id user logat ", this.loggedUser.id)
      console.log("params id ", params['id'])
      const infoUser = this.instaCookService.getUserInfoById(this.loggedUser.id).subscribe((response: any) =>{
        console.log("response: ", response)
        this.loggedUser = {
          ...this.loggedUser,
          nume: response.nume,
          prenume: response.prenume,
          telefon: response.telefon,
          tara: response.tara_Origine,
          nrPuncte: response.nrPuncte,
          email: response.email
        }
        console.log("am logged user: ", this.loggedUser)
      })
    })
  }

  getColectiiForUser(){
   this.instaCookService.getAllColectii(this.loggedUser.id).subscribe(response =>{
    this.colectiiUser = response;
    console.log("&&&&&&&",this.colectiiUser)
   })
  }

  deleteCollection(titlu: string){
    console.log("a intrat in fct de delete profile")
    this.instaCookService.deleteColectie(titlu).subscribe(response=>{
      console.log("response delete", response)
    });
    window.location.reload();
  }

  changePrivacyToggle($event: MatSlideToggleChange){
    this.showPrivateCollections = $event.checked;
  }

  filteringSweets($event: MatSlideToggleChange){
    this.filterSweets = $event.checked
  }

}
