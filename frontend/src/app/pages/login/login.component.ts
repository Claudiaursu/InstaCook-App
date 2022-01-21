import { Component, OnInit, Output } from '@angular/core';
import { Router } from '@angular/router';
import { LoginUser } from 'src/app/interfaces/login_user';
import { User } from 'src/app/interfaces/user';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  public isDisabled: boolean = false;
  public user : LoginUser = {
    Username : "",
    Parola: "",
  }
  public error : boolean | string = false

  constructor(
    private authService: AuthService,
    private router: Router
    ) { }

  ngOnInit(): void {
  }

  doLogin(){
    this.error = false

    this.authService.login(this.user).subscribe((response : any) =>{
      if(response && response.token){
        localStorage.setItem('token', response.token);
        localStorage.setItem('loggedUserId', response.id);
        localStorage.setItem('loggedUsername', response.username);

        this.router.navigate(['/homepage']);
      }
    })
  }

}
