import { Component } from '@angular/core';
import { FormBuilder,FormControl,FormGroup,Validators,ReactiveFormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { Router } from '@angular/router';

@Component({
  selector: 'app-create-business-card',
  standalone: true,
  imports: [CommonModule,ReactiveFormsModule],
  templateUrl: './create-business-card.component.html',
  styleUrl: './create-business-card.component.css'
})
export class CreateBusinessCardComponent {

  businessCardForm: FormGroup;

  constructor(private fb: FormBuilder,private router:Router) {
    // Initialize the form with FormBuilder
    this.businessCardForm = this.fb.group({
      name: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]],
      address: ['', Validators.required]
    });
  }


  onSubmit(){

    this.router.navigate(['/preview']);  }
}
