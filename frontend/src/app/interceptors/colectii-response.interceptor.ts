import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor,
  HttpResponse
} from '@angular/common/http';
import { Observable } from 'rxjs';
import { tap } from 'rxjs/operators';
import { ToastrService } from 'ngx-toastr';

@Injectable()
export class CollectiiResponseInterceptor implements HttpInterceptor {

  constructor(
    private toastr: ToastrService
  ) {}

  intercept(request: HttpRequest<unknown>, next: HttpHandler): Observable<HttpEvent<unknown>> {
    return next.handle(request).pipe(
      tap((event =>{
        if(event instanceof HttpResponse){
          console.log("event ", event)
          if(event.status == 200){
           // this.toastr.success("Data received succesfully!")
            if(event.url?.indexOf("Colectie/getAllForUser")){
              let collections: any[] = <any[]>event.body
              if(collections.length > 0){
                let fields = Object.keys(collections[0])
                let oldNewFields: Record<string, string> = {}
                fields.forEach(field =>{
                  var oldField: string = field;
                  field = field.charAt(0).toUpperCase() + field.slice(1)
                  oldNewFields[oldField] = `${field}`;
                })

                console.log("DICTIONARY WITH TRANSFORMED FIELDS ", oldNewFields)

                collections.forEach(collection =>{
                  fields.forEach(field =>{
                    collection[oldNewFields[field]] = collection[field]
                    delete collection[field]
                  })
                })
                console.log("formatted collections: ", collections)
               this.toastr.success(`There has been received ${collections.length} collections!`)
              }

            }
          }
        }
      })
    ));
  }
}
