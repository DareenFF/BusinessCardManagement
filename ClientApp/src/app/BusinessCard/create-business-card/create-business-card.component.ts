import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators, ReactiveFormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { Router, RouterOutlet } from '@angular/router';
import { MatDialog } from '@angular/material/dialog';
import { PreviewBusinessCardComponent } from '../preview-business-card/preview-business-card.component';
import { BusinessCardService } from '../../Services/business-card-service.service';
import { BusinessCard } from '../../Models/BusinessCard';

@Component({
  selector: 'app-create-business-card',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule, RouterOutlet],
  templateUrl: './create-business-card.component.html',
  styleUrls: ['./create-business-card.component.css']
})
export class CreateBusinessCardComponent {

  businessCardForm: FormGroup;
  businessCard: BusinessCard = {}; // Initialize the business card object

  constructor(
    private fb: FormBuilder,
    private router: Router,
    private dialog: MatDialog,
    private service: BusinessCardService // Injecting the service correctly
  ) {
    this.businessCardForm = this.fb.group({
      name: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]],
      address: ['', Validators.required],
      gender: ['', Validators.required] // Add the gender field
    });
  }

  onSubmit() {
    this.businessCard = this.businessCardForm.value;

    // Call the service to create the business card
    this.service.createBusinessCard(this.businessCard).subscribe(response => {
      console.log('Business card created successfully:', response);
    
      // Open the preview dialog after successful creation
      const dialogRef = this.dialog.open(PreviewBusinessCardComponent, {
        width: '400px',
        height: '400px',
        disableClose: true,
        panelClass: 'custom-dialog'
      });

      dialogRef.afterClosed().subscribe(result => {
        if (result) {
          console.log('Confirmed!');
          this.router.navigate(['/some-route']); // Replace with your desired route after confirmation
        } else {
          console.log('Cancelled!');
        }
      });

    }, error => {
      console.error('Error creating business card:', error);
      // Handle error here
    });
  }
}
