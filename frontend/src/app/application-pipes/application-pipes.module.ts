import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FilterCollectionsTogglePipe } from './private-or-public-toggle-pipe/private-or-public-toggle.pipe';


@NgModule({
  declarations: [
    FilterCollectionsTogglePipe
  ],
  imports: [
    CommonModule
  ],
  exports :[
    FilterCollectionsTogglePipe
  ]
})
export class ApplicationPipesModule { }
