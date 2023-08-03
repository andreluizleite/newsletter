import { Component } from '@angular/core';
import { NewsletterSignupService } from '../../services/newsletter-signup.service';
import { Newsletter } from './../../models/newsletter';

@Component({
  selector: 'app-newsletter-signup-form',
  templateUrl: './newsletter-signup-form.component.html',
  styleUrls: ['./newsletter-signup-form.component.css']
})
export class NewsletterSignupFormComponent {
  newsletter: Newsletter = {
    email: '',
    howHeardUs: 1,
    reason: ''
  };
  feedbackMessage = '';

  constructor(private newsletterSignupService: NewsletterSignupService) { }

  onSubmit(): void {
    if (this.validateForm()) {
      this.newsletterSignupService.submitForm(this.newsletter )
        .subscribe(
          () => {
            this.feedbackMessage = 'You have been signed up for the newsletter!';
          },
          (error) => {
            if (error.status === 400) {
              debugger;
              // Extract the error message from the response body
              const errorMessage = error.error.message || 'An unknown error occurred.';
              this.feedbackMessage = errorMessage;
            } else {
              this.feedbackMessage = 'An error occurred. Please try again later.';
              console.error(error);
            }
          }
        );
    }
  }

  validateForm(): boolean {
    if (!this.newsletter.email || !this.newsletter.howHeardUs) {
      this.feedbackMessage = 'Please fill in all required fields.';
      return false;
    }

    if (!this.isEmailValid(this.newsletter.email)) {
      this.feedbackMessage = 'Please provide a valid email address.';
      return false;
    }

    this.feedbackMessage = '';
    return true;
  }

  isEmailValid(email: string): boolean {
    const emailRegex = /^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$/;
    return emailRegex.test(email);
  }
}
