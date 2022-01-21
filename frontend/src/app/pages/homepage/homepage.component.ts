import { Component, Input, OnInit } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { User } from 'src/app/interfaces/user';
import { PrivateService } from 'src/app/services/private.service';
import { UserInfoComponent } from 'src/app/shared/user-info/user-info.component';

@Component({
  selector: 'app-homepage',
  templateUrl: './homepage.component.html',
  styleUrls: ['./homepage.component.css']
})
export class HomepageComponent implements OnInit {

  public users: any[] = []
  public loggedUser: any;
  displayedColumns: string[] = ['nume', 'prenume', 'username'];
  constructor(private privateService: PrivateService) { }

  ngOnInit(): void {
    this.getAllUsers();
    this.checkLogin();
    console.log(this.loggedUser)
  }

  checkLogin(){
    if(localStorage.getItem('token') != null){
      this.loggedUser = {
        username: localStorage.getItem('loggedUsername'),
        token: localStorage.getItem('token'),
        id: localStorage.getItem('loggedUserId')
      }
    }
  }

  getAllUsers(){
    console.log("a intrat la fct all users")
    this.privateService.getUsers().subscribe((response : any) =>{
      this.users = response
      console.log("respnse: ", response)
    })
  }

}
