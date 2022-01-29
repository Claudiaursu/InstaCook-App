import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PrivateOrPublicTogglePipe } from './private-or-public-toggle-pipe/private-or-public-toggle.pipe';


@NgModule({
  declarations: [
    PrivateOrPublicTogglePipe
  ],
  imports: [
    CommonModule
  ],
  exports :[
    PrivateOrPublicTogglePipe
  ]
})
export class ApplicationPipesModule { }
