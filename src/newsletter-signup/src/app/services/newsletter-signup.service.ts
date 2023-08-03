import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class NewsletterSignupService {
  private apiUrl = 'https://localhost:7147';

  constructor(private http: HttpClient) { }

  submitForm(userData: any) {
    return this.http.post<any>(`${this.apiUrl}/api/v1/Newsletter`, userData);
  }
}
