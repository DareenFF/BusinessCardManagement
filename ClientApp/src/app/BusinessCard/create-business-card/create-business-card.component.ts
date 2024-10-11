import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators, ReactiveFormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { Router, RouterOutlet } from '@angular/router';
import { MatDialog } from '@angular/material/dialog';
import { PreviewBusinessCardComponent } from '../preview-business-card/preview-business-card.component';
import { BusinessCardService } from '../../Services/business-card-service.service';
import { BusinessCard } from '../../Models/BusinessCard';
import { debounce } from 'rxjs';


@Component({
  selector: 'app-create-business-card',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule, RouterOutlet],
  templateUrl: './create-business-card.component.html',
  styleUrls: ['./create-business-card.component.css']
})
export class CreateBusinessCardComponent {

  businessCardForm: FormGroup;
  businessCard: BusinessCard = {}; 

  constructor(
    private fb: FormBuilder,
    private router: Router,
    private dialog: MatDialog,
    private service: BusinessCardService,
  ) {
    this.businessCardForm = this.fb.group({
      name: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]],
      address: ['', Validators.required],
      gender: ['', Validators.required] ,
      phone:[''],
      dob:['']
    });
  }

  onSubmit() {
    console.log('Form submitted:', this.businessCardForm.value);
    this.businessCard = this.businessCardForm.value;

    if (this.businessCardForm.valid) {
        this.service.createBusinessCard(this.businessCard).subscribe({
            next: response => {
                console.log('Business card created successfully:', response);

                this.router.navigate(['/']);
               
            },
            error: error => {
                console.error('Error creating business card:', error);
            }
        });
    } else {
        console.log('Form is invalid, not submitting.'); 
    }
}

UploadFile(){


  
}

    // console.log(this.businessCard);
    // this.businessCard = this.businessCardForm.value;

    // if(this.businessCardForm.valid){
    //   this.service.createBusinessCard(this.businessCard);

    // }
    
    //.subscribe(response => {
    //   console.log('Business card created successfully:', response);
    
    //   // Open the preview dialog after successful creation
    //   const dialogRef = this.dialog.open(PreviewBusinessCardComponent, {
    //     width: '400px',
    //     height: '400px',
    //     disableClose: true,
    //     panelClass: 'custom-dialog'
    //   });

    //   dialogRef.afterClosed().subscribe(result => {
    //     if (result) {
    //       console.log('Confirmed!');
    //       this.router.navigate(['/some-route']); // Replace with your desired route after confirmation
    //     } else {
    //       console.log('Cancelled!');
    //     }
    //   });

    // }, error => {
    //   console.error('Error creating business card:', error);
    //   // Handle error here
    // });
  
}


