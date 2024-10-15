import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators, ReactiveFormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { Router, RouterOutlet } from '@angular/router';
import { MatDialog,MatDialogModule  } from '@angular/material/dialog';
import { PreviewBusinessCardComponent } from '../preview-business-card/preview-business-card.component';
import { BusinessCardService } from '../../Services/business-card-service.service';
import { BusinessCard } from '../../Models/BusinessCard';
import { response } from 'express';
import { error } from 'console';




@Component({
  selector: 'app-create-business-card',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule, RouterOutlet,MatDialogModule ],
  templateUrl: './create-business-card.component.html',
  styleUrls: ['./create-business-card.component.css']
})
export class CreateBusinessCardComponent {

  businessCardForm: FormGroup;
  businessCard: BusinessCard = {}; 
  selectedFile: File | null = null; 


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
    if(this.selectedFile){

      this.service.createBusinessCardByFileUpload(this.selectedFile).subscribe({
       next:response=>{
         console.log("file created",response);
         this.router.navigate(['/']);
       },
       error:error=>{
         console.error('error handling the file',error); 
       }
      })

     }else{
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
  }

OpenPreviewPage(): void {
  if (this.businessCardForm.valid) {
    const dialogRef = this.dialog.open(PreviewBusinessCardComponent, {
      width: '400px',
      height:'600px',
      data: this.businessCardForm.value,
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        this.onSubmit();
      }
    });
  }
}

UploadFile(event:Event){

  const input = event.target as HTMLInputElement;
    if (input.files && input.files.length > 0) {
      this.selectedFile = input.files[0]; // Store the selected file
    }

    // if(this.selectedFile){
    // this.service.createBusinessCardByFileUpload(this.selectedFile);
    // }
}


  
}


