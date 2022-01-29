import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CollectionNewComponent } from './collections/collection-new/collection-new.component';
import { RetetaInfoComponent } from './collections/reteta-info/reteta-info.component';
import { ExitPermissionGuard } from './guards/exit-permission.guard';
import { HasPermissionGuard } from './guards/has-permission.guard';
import { HomepageComponent } from './pages/homepage/homepage.component';
import { LoginComponent } from './pages/login/login.component';
import { ProfileComponent } from './pages/profile/profile.component';
import { RegisterComponent } from './pages/register/register.component';

const routes: Routes = [
  {
    path: "",
    redirectTo: "/login",
    pathMatch: "full"
  },
  {
    path: "login",
    component: LoginComponent
  },
  {
    path: "register",
    component: RegisterComponent
  },
  {
    path: "homepage",
    component: HomepageComponent
  },
  {
    path: 'profile/:id',
    component: ProfileComponent
  },
  {
    path: 'profile/:id/newCollection',
    component: CollectionNewComponent,
    canDeactivate: [ExitPermissionGuard]
  },
  {
    path: 'retete',
    component: RetetaInfoComponent,
    canActivate: [HasPermissionGuard]
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
