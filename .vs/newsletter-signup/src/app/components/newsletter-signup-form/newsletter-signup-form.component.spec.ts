import { ComponentFixture, TestBed } from '@angular/core/testing';

import { NewsletterSignupFormComponent } from './newsletter-signup-form.component';

describe('NewsletterSignupFormComponent', () => {
  let component: NewsletterSignupFormComponent;
  let fixture: ComponentFixture<NewsletterSignupFormComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [NewsletterSignupFormComponent]
    });
    fixture = TestBed.createComponent(NewsletterSignupFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
