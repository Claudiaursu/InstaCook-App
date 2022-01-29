import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'privateOrPublicToggle'
})
export class PrivateOrPublicTogglePipe implements PipeTransform {

  transform(collections: any[], showPrivacy: boolean): any[] {
    return collections.filter((collection)=>{
      if(collection.publica == showPrivacy){
        return collection
      }
    })
  }

}
