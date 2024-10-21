import { HttpClient } from '@angular/common/http';
import { Component, inject, OnInit } from '@angular/core';
import { User } from './models/user';
import { UserService } from './services/user.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent  implements OnInit{
  http = inject(HttpClient);
  title = 'Directory';
  applications: any;

  constructor(private userService: UserService) {}

  ngOnInit(): void {
    this.setCurrentUser();
  }

  setCurrentUser()
  {
    const userString = localStorage.getItem('user');
    if(!userString) return;
    const user: User = JSON.parse(userString);
    this.userService.setCurrentUser(user);
  }
}
