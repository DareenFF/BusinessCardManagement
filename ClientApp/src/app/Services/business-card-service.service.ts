import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { BusinessCard } from '../Models/BusinessCard';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class BusinessCardService {

  constructor(private http: HttpClient) { }

  getBusinessCards(): Observable<BusinessCard[]> {
    return this.http.get<BusinessCard[]>(environment.apiUrl+'/get');
  }

  createBusinessCard(businessCard: BusinessCard): Observable<BusinessCard> {
    return this.http.post<BusinessCard>(environment.apiUrl, businessCard);
  }


  deleteBusinessCard(id: number): Observable<void> {
    return this.http.delete<void>(`${environment.apiUrl}/${id}`);
  }
}
