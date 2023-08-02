import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class NewsletterSignupService {
  private apiUrl = 'http://your-backend-api-url'; // Replace this with your actual backend API URL

  constructor(private http: HttpClient) { }

  submitForm(userData: any) {
    // Mock API call to your backend
    return this.http.post<any>(`${this.apiUrl}/newsletter/signup`, userData);
  }
}
