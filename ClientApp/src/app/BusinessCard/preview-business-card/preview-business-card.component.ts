import { Component, Inject } from '@angular/core';
import { MatDialogModule,MatDialogActions, MatDialogContent, MatDialogRef,MAT_DIALOG_DATA } from '@angular/material/dialog';
import { CommonModule } from '@angular/common';




@Component({
  selector: 'app-preview-business-card',
  standalone: true,
  imports: [MatDialogActions,MatDialogContent,CommonModule,MatDialogModule],
  templateUrl: './preview-business-card.component.html',
  styleUrl: './preview-business-card.component.css',
  providers: [], 

})
export class PreviewBusinessCardComponent {

  constructor(
    @Inject(MAT_DIALOG_DATA) public data: any,
    private dialogRef: MatDialogRef<PreviewBusinessCardComponent>
    
  ) {console.log(data);}
onConfirm(): void {
    this.dialogRef.close(true); 
  }

  onCancel(): void {
    this.dialogRef.close(false); 
  }
}
