import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor,
  HttpErrorResponse,
} from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';


@Injectable()
export class HttpErrorsInterceptor implements HttpInterceptor {
  constructor(
    private router: Router,
    private toastr: ToastrService
    ) {}

  intercept(
    request: HttpRequest<unknown>,
    next: HttpHandler
  ): Observable<HttpEvent<unknown>> {
    console.log("request info from interceptor: ",request);
    return next.handle(request).pipe(
      catchError((error: HttpErrorResponse) => {
        console.log("eroare from interceptor:", error);
        console.log(error.status, error.error.message);
        if (error.status == 500) {
          this.toastr.error("Sorry! There has been an internal Server Error")
        }
        if (error.status == 400 && error.url?.split("/").slice(-1)[0] === 'authenticate') {
          this.toastr.error("Please enter again your credentials!")
          this.router.navigate(['/login']);
        }
        if(error.status == 401){
          this.toastr.error("You were not allowed to enter that page! Please login!")
          this.router.navigate(['/login']);
        }
        return throwError(error);
      })
    );
  }
}
