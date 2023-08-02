import { Component } from '@angular/core';
import { NewsletterSignupService } from '../../services/newsletter-signup.service';

@Component({
  selector: 'app-newsletter-signup-form',
  templateUrl: './newsletter-signup-form.component.html',
  styleUrls: ['./newsletter-signup-form.component.css']
})
export class NewsletterSignupFormComponent {
  user = { email: '', howHeard: '', reason: '' };
  feedbackMessage = '';

  constructor(private newsletterSignupService: NewsletterSignupService) { }

  onSubmit(): void {
    if (this.validateForm()) {
      this.newsletterSignupService.submitForm(this.user)
        .subscribe(
          () => {
            this.feedbackMessage = 'You have been signed up for the newsletter!';
          },
          (error) => {
            this.feedbackMessage = 'An error occurred. Please try again later.';
            console.error(error);
          }
        );
    }
  }

  validateForm(): boolean {
    if (!this.user.email || !this.user.howHeard) {
      this.feedbackMessage = 'Please fill in all required fields.';
      return false;
    }

    if (!this.isEmailValid(this.user.email)) {
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
