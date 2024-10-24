import { Component, OnInit } from '@angular/core';
import { UserService } from '../services/user.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit{
 
  model: any = {};
  loggedIn = false;

  constructor(public userService: UserService,  private router: Router){}

  ngOnInit(): void {
  }
  login() {
    this.userService.login(this.model).subscribe({
      next: () => {
        this.router.navigateByUrl('/dashboard');
        this.model = {};
      }
    })
  }
  logout(){
    this.userService.logout();
    this.router.navigateByUrl('/');
  }
}
