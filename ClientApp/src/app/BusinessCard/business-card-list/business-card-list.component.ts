import { Component, OnInit } from '@angular/core';
import { BusinessCard } from '../../Models/BusinessCard';
import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http'; 
import { BusinessCardService } from '../../Services/business-card-service.service';

import { Observable } from 'rxjs';

@Component({
  selector: 'app-business-card-list',
  standalone: true,
  templateUrl: './business-card-list.component.html',
  styleUrls: ['./business-card-list.component.css'],
  imports:[CommonModule,HttpClientModule]
})
export class BusinessCardListComponent implements OnInit {
  businessCards!: Observable<BusinessCard[]>; // Use BusinessCard type


  constructor(private service:BusinessCardService){


  }

  ngOnInit() {

    this.businessCards= this.service.getBusinessCards();
    console.log('Business Cards:', this.businessCards); // Ensure this prints the array correctly
  }



  OnDelete(id:number){


    console.log('action triggered');

    this.service.deleteBusinessCard(id).subscribe(() => {
      console.log('Business card deleted successfully');
      this.ngOnInit(); // Refresh the list after deletion
    }, error => {
      console.error('Error deleting business card:', error);
    });
//this.service.deleteBusinessCard(id);

console.log('deletion successfull');

  }

  ExportCardsToXML(){


    this.service.exportBusinessCards('XML').subscribe((data: Blob) => {
      const blob = new Blob([data], { type: 'application/xml' });
      const url = window.URL.createObjectURL(blob);
      const a = document.createElement('a');
      a.href = url;
      a.download = 'BusinessCards.xml';
      a.click();
      window.URL.revokeObjectURL(url);
  });  }
  ExportCardsToCSV(){


    this.service.exportBusinessCards('CSV').subscribe((data: Blob) => {
      const blob = new Blob([data], { type: 'text/csv' });
      const url = window.URL.createObjectURL(blob);
      const a = document.createElement('a');
      a.href = url;
      a.download = 'BusinessCards.csv';
      a.click();
      window.URL.revokeObjectURL(url);
  });
  }
}
