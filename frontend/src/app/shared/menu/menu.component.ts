import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-menu',
  templateUrl: './menu.component.html',
  styleUrls: ['./menu.component.css']
})
export class MenuComponent implements OnInit {

  @Input() user: any = null;
  constructor(
      private router: Router
    ) { }

  ngOnInit(): void {
    console.log("print user din menu: ", this.user)
  }

  logout(){
    localStorage.removeItem('token');
    localStorage.removeItem('loggedUserId');
    localStorage.removeItem('loggedUsername');
    this.router.navigate(['/homepage']);
    window.location.reload();
  }

}
