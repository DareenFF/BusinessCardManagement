import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { catchError, Observable, of, throwError } from 'rxjs';
import { BusinessCard } from '../Models/BusinessCard';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class BusinessCardService {

  constructor(private http: HttpClient) { }

  getBusinessCards(): Observable<BusinessCard[]> {
    return this.http.get<BusinessCard[]>(`${environment.apiUrl}get`).pipe(
      catchError(error => {
          console.error('Error fetching business cards', error);
          return of([]); 
      })
  );  }

  createBusinessCard(businessCard: BusinessCard): Observable<BusinessCard> {

    console.log('url:' + environment.apiUrl);

    return this.http.post<BusinessCard>(environment.apiUrl, businessCard).pipe(
      catchError((error: any) => {
        console.error('Error:', error);
        return throwError(error);
      })
    );  }

    createBusinessCardByFileUpload(file:File):Observable<any>{

      const formData = new FormData();
      formData.append('file', file); // The name should match the parameter in your endpoint
  
      return this.http.post(`${environment.apiUrl}UploadFile`, formData); // Update this with your file upload endpoint
    }
    


  deleteBusinessCard(id: number): Observable<void> {
    return this.http.delete<void>(`${environment.apiUrl}${id}`);
  }

  exportBusinessCards(format:string){
    return this.http.get(`${environment.apiUrl}ExportCards?format=${format}`, { responseType: 'blob' });
  }

  getBusinessCardsByAddress(address:string): Observable<BusinessCard[]> {
    console.log(`Calling API: ${environment.apiUrl}FilterByAddress?address=${address}`); // Verify correct URL

    return this.http.get<BusinessCard[]>(`${environment.apiUrl}FilterByAddress?address=${address}`).pipe(
      catchError(error => {
          console.error('Error fetching business cards', error);
          return of([]); 
      })
  );  }
}
