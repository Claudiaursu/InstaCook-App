import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CollectionInfoComponent } from './collection-info/collection-info.component';
import { CollectionNewComponent } from './collection-new/collection-new.component';
import { AppRoutingModule } from '../app-routing.module';
import {MatMenuModule} from '@angular/material/menu';
import {MatIconModule} from '@angular/material/icon';
import { MenuComponent } from '../shared/menu/menu.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { SharedModule } from '../shared/shared.module';
import {MatSlideToggleModule} from '@angular/material/slide-toggle';
import {MatCardModule} from '@angular/material/card';


@NgModule({
  declarations: [
    CollectionInfoComponent,
    CollectionNewComponent,
  ],
  imports: [
    CommonModule,
    AppRoutingModule,
    MatMenuModule,
    MatIconModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    SharedModule,
    MatSlideToggleModule,
    MatCardModule,
  ],
  exports: [
    CollectionInfoComponent,
    CollectionNewComponent
  ]
})
export class CollectionsModule { }
