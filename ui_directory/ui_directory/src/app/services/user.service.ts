import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { user } from '../models/user';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  private http = inject(HttpClient);
  baseUrl = "https://localhost:7214/api/";

  login(user: user){
    return this.http.post(this.baseUrl + 'user/login',user);
  }
}
