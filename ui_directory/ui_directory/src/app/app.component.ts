import { HttpClient } from '@angular/common/http';
import { Component, inject, OnInit } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent  implements OnInit{
  http = inject(HttpClient);
  title = 'ui_directory';
  applications: any;

  ngOnInit(): void {
    this.http.get('https://localhost:7214/api/application/list').subscribe({
      next: response => this.applications = response,
      error: error => console.log(error),
      complete() {}     
    });
  }
}
