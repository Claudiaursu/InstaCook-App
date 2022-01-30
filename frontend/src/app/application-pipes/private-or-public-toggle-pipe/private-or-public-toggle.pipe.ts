import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'filterCollectionsToggle'
})
export class FilterCollectionsTogglePipe implements PipeTransform {

  // this pipe filters the collections based on two factors:
  // Show both private and public collections or only private (default)
  // Show collections that are meant for sweets recipes or all collections
  // the two filters (toggle buttons that are selected) are applied both
  transform(collections: any[], showPrivacy: boolean, filterSweets: boolean): any[] {
    let privacyResolvedCollections = collections.filter((collection)=>{
      if(showPrivacy == false){
        if(collection.publica == showPrivacy){
          return collection
        }
      }
      else {
        return collection
      }
    })
    if(filterSweets){
      return privacyResolvedCollections.filter(collection =>{
        if(collection.titlu_Colectie.toLowerCase().indexOf('desert') != -1 || collection.descriere_Colectie.toLowerCase().indexOf('desert') != -1){
          return collection
        }
      })
    }
    return privacyResolvedCollections
  }

}
