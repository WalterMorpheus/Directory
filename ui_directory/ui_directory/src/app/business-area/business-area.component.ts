import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-business-area',
  templateUrl: './business-area.component.html',
  styleUrls: ['./business-area.component.css']
})
export class BusinessAreaComponent implements OnInit {

  businessArea: any = {};
  newBusinessAreaType: any = {};
  businessAreaTypes: any[] = [];
  businessAreas: any[] = [];
  relationship: any = {};
  typeRelationship: any = {};

  constructor(){}

  ngOnInit(): void {
  }


  addBusinessAreaType() {
    /*this.businessAreaService.createBusinessAreaType(this.newBusinessAreaType).subscribe(response => {
      console.log('Business Area Type created:', response);
      this.loadBusinessAreaTypes();  // Reload business area types after creation
    });*/
  }

  onSubmit() {
    /*this.businessAreaService.createBusinessArea(this.businessArea).subscribe(response => {
      console.log('Business Area created:', response);
      this.loadBusinessAreas();  // Reload business areas after creation
    });*/
  }

   // Create a new Business Area Relationship
   onSubmitRelationship() {
    /*this.businessAreaService.createBusinessAreaRelationship(this.relationship).subscribe(response => {
      console.log('Business Area Relationship created:', response);
    });*/
  }

  onSubmitTypeRelationship() {
    /*this.businessAreaService.createBusinessAreaTypeRelationship(this.typeRelationship).subscribe(response => {
      console.log('Business Area Type Relationship created:', response);
    });*/
  }

}
