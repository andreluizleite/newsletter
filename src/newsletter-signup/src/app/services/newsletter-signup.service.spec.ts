import { TestBed } from '@angular/core/testing';

import { NewsletterSignupService } from './newsletter-signup.service';

describe('NewsletterSignupService', () => {
  let service: NewsletterSignupService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(NewsletterSignupService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
