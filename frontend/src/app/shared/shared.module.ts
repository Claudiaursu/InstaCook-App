import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { UserInfoComponent } from './user-info/user-info.component';
import { MenuComponent } from './menu/menu.component';
import {MatMenuModule} from '@angular/material/menu';
import {MatIconModule} from '@angular/material/icon';
import { AppRoutingModule } from '../app-routing.module';


@NgModule({
  declarations: [
    UserInfoComponent,
    MenuComponent
  ],
  imports: [
    CommonModule,
    AppRoutingModule,
    MatMenuModule,
    MatIconModule,
  ],
  exports: [
    UserInfoComponent,
    MenuComponent
  ]
})
export class SharedModule { }
