import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor,
  HttpErrorResponse
} from '@angular/common/http';
import { Observable, catchError, pipe } from 'rxjs';
import { NavigationExtras, Router } from '@angular/router';

@Injectable()
export class ErrorInterceptor implements HttpInterceptor {

  constructor(private routor: Router) {}

  intercept(request: HttpRequest<unknown>, next: HttpHandler): Observable<HttpEvent<unknown>> {
    return next.handle(request).pipe(
      catchError((error: HttpErrorResponse)=>{
        if(error){
        switch(error.status){
          case 400:
            if(error.error.errors){
              const modelStateErrors = [];
              for(const key in error.error.errors){
                if(error.error.errors[key]){
                  modelStateErrors.push(error.error.errors[key])
                }
              }
              throw modelStateErrors.flat();
            }else{
              console.log(error.status.toString())
            }
            break;
          case 401:
            console.log(error.status.toString())
            break;
          case 404:
            this.routor.navigateByUrl('Unauthorised');
            break;
          case 500:
            const navigationExtras: NavigationExtras = {state: {error: error.error}};
            this.routor.navigateByUrl('/server-error',navigationExtras);
           break;
          default:
            this.routor.navigateByUrl('Something unexpected went wrong');
            console.log(error);
           break;
        }
      }
        throw error;
      })
    )
  }
}
