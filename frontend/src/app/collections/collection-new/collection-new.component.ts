import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatSlideToggleChange } from '@angular/material/slide-toggle';
import { Router } from '@angular/router';
import { Colectie } from 'src/app/interfaces/colectie';
import { CollectionService } from 'src/app/services/collection.service';

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
    private collectionService: CollectionService,
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
    this.addDeafultExitPermissions()
  }

  addDeafultExitPermissions(){
    let permissions = localStorage.getItem('permissions')
    if(permissions){
      const permissionsParsed = JSON.parse(permissions)
      permissions = {
        ...permissionsParsed,
        exitNewCollection: "true"
      }
      localStorage.setItem('permissions', JSON.stringify(permissions))
      console.log("permissions: ",JSON.parse(localStorage.getItem('permissions') || ''))
    }
  }

  removeExitPermissions(){
    let permissions = localStorage.getItem('permissions')
    if(permissions){
      const permissionsParsed = JSON.parse(permissions)
      permissions = {
        ...permissionsParsed,
        exitNewCollection: "false"
      }
      localStorage.setItem('permissions', JSON.stringify(permissions))
      console.log("permissions: ",JSON.parse(localStorage.getItem('permissions') || ''))
    }
  }

  getExitPermission(){
    let permissions = localStorage.getItem('permissions')
    if(permissions){
      const permissionsParsed = JSON.parse(permissions)
      if(permissionsParsed?.exitNewCollection == "true"){
        return true;
      }
      return false;
    }
    return false;
  }

  onChangeToggle($event: MatSlideToggleChange){
    console.log($event)
    this.newCollectionForm.get('publica')?.patchValue($event.checked)
  }

  onKeyUpTitle($event: any){
    if(this.newCollectionForm.value.titlu != ''){
      this.removeExitPermissions();
    }
    else{
      this.addDeafultExitPermissions();
    }
  }

  onKeyUpDescriere($event: any){
    if(this.newCollectionForm.value.descriere != ''){
      this.removeExitPermissions();
    }
    else{
      this.addDeafultExitPermissions();
    }
  }

  createNewCollection(){
    console.log(this.newCollectionForm)
    if(this.newCollectionForm.valid){

      this.addDeafultExitPermissions();
      let collection : Colectie = {
        Titlu_Colectie: this.newCollectionForm.value.titlu,
        Descriere_Colectie: this.newCollectionForm.value.descriere,
        Publica: this.newCollectionForm.value.publica,
        Cale_Poza: ''
      }
      console.log(collection)
      this.collectionService.createNewColection(this.loggedUser.id, collection).subscribe(response =>{
        console.log(response)
      })
    }
    this.router.navigate([`/profile/${this.loggedUser.id}`])
  }
}
