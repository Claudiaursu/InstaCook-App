import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginComponent } from './pages/login/login.component';
import { RegisterComponent } from './pages/register/register.component';
import { HomepageComponent } from './pages/homepage/homepage.component';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { NoopAnimationsModule } from '@angular/platform-browser/animations'
import {MatTableModule} from '@angular/material/table';
import { HttpErrorsInterceptor } from './interceptors/http-errors.interceptor';
import { ProfileComponent } from './pages/profile/profile.component';
import { SharedModule } from './shared/shared.module';
import { MatIconModule } from '@angular/material/icon';
import { MatMenuModule } from '@angular/material/menu';
import {MatCardModule} from '@angular/material/card';
import { CollectionsModule } from './collections/collections.module';
import { PrivateOrPublicTogglePipe } from './application-pipes/private-or-public-toggle-pipe/private-or-public-toggle.pipe';
import { MatSlideToggleModule } from '@angular/material/slide-toggle';
import { ApplicationPipesModule } from './application-pipes/application-pipes.module';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    RegisterComponent,
    HomepageComponent,
    ProfileComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule,
    NoopAnimationsModule,
    ReactiveFormsModule,
    MatTableModule,
    SharedModule,
    CollectionsModule,
    MatIconModule,
    MatMenuModule,
    MatCardModule,
    MatSlideToggleModule,
  ],
  providers: [
    {
      provide: HTTP_INTERCEPTORS,
      useClass: HttpErrorsInterceptor,
      multi: true,
    }
  ],
  bootstrap: [AppComponent],
})
export class AppModule { }
