import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class NewsletterSignupService {
  private apiUrl = 'http://your-backend-api-url';

  constructor(private http: HttpClient) { }

  submitForm(userData: any) {
    return this.http.post<any>(`${this.apiUrl}/newsletter/signup`, userData);
  }
}
