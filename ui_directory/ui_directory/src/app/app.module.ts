import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { HTTP_INTERCEPTORS, HttpClientModule} from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NavComponent } from './nav/nav.component';
import { RouteReuseStrategy } from '@angular/router';
import { ErrorInterceptor } from './interceptors/error.interceptor';
import { JwtInterceptor } from './interceptors/jwt.interceptor';
import { LoadingInterceptor } from './interceptors/loading.interceptor';
import { CustomRouteReuseStrategy } from './services/customRouteReuseStrategy';
import { NgxSpinnerModule } from 'ngx-spinner';
import { RegisterComponent } from './register/register.component';
import { HomeComponent } from './home/home.component';
import { TextInputComponent } from './form/text-input/text-input.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { ApplicationComponent } from './application/application.component';


@NgModule({
  declarations: [
    AppComponent,
    NavComponent,
    RegisterComponent,
    HomeComponent,
    TextInputComponent,
    DashboardComponent,
    ApplicationComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    HttpClientModule,
    ReactiveFormsModule ,
    NgxSpinnerModule,
    FormsModule  
  ],
  providers: [
    {provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor,multi: true},
    {provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor,multi: true},
    {provide: HTTP_INTERCEPTORS, useClass: LoadingInterceptor,multi: true},
    {provide: RouteReuseStrategy, useClass: CustomRouteReuseStrategy}
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
