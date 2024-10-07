import { Component, OnInit } from '@angular/core';
import { BusinessCard } from '../../Models/BusinessCard';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-business-card-list',
  standalone: true,
  templateUrl: './business-card-list.component.html',
  styleUrls: ['./business-card-list.component.css'],
  imports:[CommonModule]
})
export class BusinessCardListComponent implements OnInit {
  businessCards:BusinessCard[] = [
    { name: 'John Doe', email: 'john@example.com',  address: 'Example Inc.' },
    { name: 'Jane Smith', email: 'jane@example.com', address: 'Sample LLC' },
    // Add more business cards as needed
  ];

  ngOnInit() {
    console.log('Business Cards:', this.businessCards); // Ensure this prints the array correctly
  }
}
