import { Component } from '@angular/core';
import { MatDialogActions, MatDialogContent, MatDialogRef } from '@angular/material/dialog';


@Component({
  selector: 'app-preview-business-card',
  standalone: true,
  imports: [MatDialogActions,MatDialogContent],
  templateUrl: './preview-business-card.component.html',
  styleUrl: './preview-business-card.component.css'
})
export class PreviewBusinessCardComponent {

constructor(public dialogRef: MatDialogRef<PreviewBusinessCardComponent>){


}
onConfirm(): void {
    this.dialogRef.close(true); // Return true on confirmation
  }

  onCancel(): void {
    this.dialogRef.close(false); // Return false on cancellation
  }
}
