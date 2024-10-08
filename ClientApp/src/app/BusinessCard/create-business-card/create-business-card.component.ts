import { Component } from '@angular/core';
import { FormBuilder,FormControl,FormGroup,Validators,ReactiveFormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { Router,RouterOutlet } from '@angular/router';
import { MatDialog } from '@angular/material/dialog';
import { PreviewBusinessCardComponent } from '../preview-business-card/preview-business-card.component';

@Component({
  selector: 'app-create-business-card',
  standalone: true,
  imports: [CommonModule,ReactiveFormsModule,RouterOutlet],
  templateUrl: './create-business-card.component.html',
  styleUrl: './create-business-card.component.css'
})
export class CreateBusinessCardComponent {

  businessCardForm: FormGroup;

  constructor(private fb: FormBuilder,private router:Router, private dialog:MatDialog) {
    // Initialize the form with FormBuilder
    this.businessCardForm = this.fb.group({
      name: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]],
      address: ['', Validators.required]
    });
  }


  onSubmit(){

    //this.router.navigate(['/preview']);  }


    const dialogRef = this.dialog.open(PreviewBusinessCardComponent, {
      width: '400px',
      height:'400px',
      disableClose: true,
      panelClass: 'custom-dialog' 
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        // Handle the confirmation action here
        console.log('Confirmed!');
      } else {
        // Handle the cancellation action here
        console.log('Cancelled!');
      }
    });
  }
}
