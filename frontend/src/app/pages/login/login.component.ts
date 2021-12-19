import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  public isDisabled: boolean = false;
  public user : any = {
    Username : "",
    Parola: ""
  }
  public error : boolean | string = false

  constructor(
    private authService: AuthService,
    private router: Router
    ) { }

  ngOnInit(): void {
  }

  doLogin(){
    console.log("trala")
    this.error = false

    this.authService.login(this.user).subscribe((response : any) =>{
      console.log("RASPUNS logare: ", response)
      if(response && response.token){
        localStorage.setItem('token', response.token);
        this.router.navigate(['/homepage']);
      }
    })
  }

}
