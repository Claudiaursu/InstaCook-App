import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanDeactivate, RouterStateSnapshot, UrlTree } from '@angular/router';
import { Observable } from 'rxjs';
import { CollectionNewComponent } from '../collections/collection-new/collection-new.component';

@Injectable({
  providedIn: 'root'
})
export class ExitPermissionGuard implements CanDeactivate<CollectionNewComponent> {
  canDeactivate(
    component: CollectionNewComponent,
    currentRoute: ActivatedRouteSnapshot,
    currentState: RouterStateSnapshot,
    nextState?: RouterStateSnapshot): Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree {
      alert("Nu poti parasi pagina! Ai date nesalvate!")
      return component.getExitPermission();
    }

}
