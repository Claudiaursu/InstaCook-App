import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatSlideToggleChange } from '@angular/material/slide-toggle';
import { Router } from '@angular/router';
import { Colectie } from 'src/app/interfaces/colectie';
import { InstaCookService } from 'src/app/services/instacook.service';

@Component({
  selector: 'app-collection-new',
  templateUrl: './collection-new.component.html',
  styleUrls: ['./collection-new.component.css']
})
export class CollectionNewComponent implements OnInit {

  public newCollectionForm!: FormGroup;
  loggedUser: any;

  constructor(
    private formBuilder: FormBuilder,
    private instaCookService: InstaCookService,
    private router: Router
  ) { }

  ngOnInit(): void {
    this.newCollectionForm = this.formBuilder.group({
      titlu:['', Validators.required],
      descriere: [''],
      publica: [false]
    })
    this.loggedUser = {
      id: localStorage.getItem('loggedUserId'),
      username: localStorage.getItem('loggedUsername'),
      token: localStorage.getItem('token'),
    }
  }

  onChangeToggle($event: MatSlideToggleChange){
    console.log($event)
    this.newCollectionForm.get('publica')?.patchValue($event.checked)
  }

  createNewCollection(){
    console.log(this.newCollectionForm)
    if(this.newCollectionForm.valid){

      let collection : Colectie = {
        Titlu_Colectie: this.newCollectionForm.value.titlu,
        Descriere_Colectie: this.newCollectionForm.value.descriere,
        Publica: this.newCollectionForm.value.publica,
        Cale_Poza: ''
      }
      console.log(collection)
      this.instaCookService.createNewColection(this.loggedUser.id, collection).subscribe(response =>{
        console.log(response)
      })
  }
  }
}
