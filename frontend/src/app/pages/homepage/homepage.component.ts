import { Component, OnInit } from '@angular/core';
import { PrivateService } from 'src/app/services/private.service';

@Component({
  selector: 'app-homepage',
  templateUrl: './homepage.component.html',
  styleUrls: ['./homepage.component.css']
})
export class HomepageComponent implements OnInit {

  public users: any[] = []
  displayedColumns: string[] = ['nume', 'prenume', 'username'];
  constructor(private privateService: PrivateService) { }

  ngOnInit(): void {
    this.getAllUsers();
  }

  getAllUsers(){
    console.log("a intrat la fct all users")
    this.privateService.getUsers().subscribe((response : any) =>{
      this.users = response
      console.log("respnse: ", response)
    })
  }

}
