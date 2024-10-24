import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-person',
  templateUrl: './person.component.html',
  styleUrls: ['./person.component.css']
})
export class PersonComponent implements OnInit {
  
  person: any = {};
  businessAreas: any[] = [];
  persons: any[] = [];

  constructor(){}
  
  ngOnInit(): void {
  }

  onSubmit() {
    /*this.personService.createPerson(this.person).subscribe(response => {
      console.log('Person created:', response);
      this.loadPersons();  // Reload persons after creation
    });*/
  }
}
