import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  public newUserForm!: FormGroup;
  public emailRegex: any = "^[a-z0-9._%+-]+@[a-z0-9.-]+\\.[a-z]{2,4}$";
  constructor(
    private formBuilder: FormBuilder,
    private authService: AuthService,
    private router: Router
    ) { }

  ngOnInit(): void {
    this.newUserForm = this.formBuilder.group({
      username: ['', [Validators.required, Validators.maxLength(15)]],
      nume: ['', Validators.required],
      prenume: ['', Validators.required],
      parola: ['', [Validators.required, Validators.minLength(5)]],
      email: ['', Validators.pattern(this.emailRegex)],
      taraOrigine: [''],
      telefon: ['']
    })
  }

  createNewAccount(){
    const url = '/Utilizator'
    console.log(this.newUserForm)
    if(this.newUserForm.valid){

      let userToCreate = {
        Nume_Utilizator: this.newUserForm.value.nume,
        Prenume_Utilizator: this.newUserForm.value.prenume,
        Parola_Hashed: this.newUserForm.value.parola,
        Date_Personale: {
          Email: this.newUserForm.value.email,
          Tara_Origine: this.newUserForm.value.taraOrigine,
          Telefon: this.newUserForm.value.telefon
        },
        Total_Puncte: 0,
        Username: this.newUserForm.value.username,
        Rol: 0
      }
      console.log(userToCreate)
      this.authService.register(userToCreate).subscribe((response : any) =>{
        console.log("RASPUNS register: ", response)
        if(response){
          this.router.navigate(['/homepage']);
        }
      })
    }
  }

}
