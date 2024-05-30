import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ContributionRequestComponent } from './contribution-request.component';

describe('ContributionRequestComponent', () => {
  let component: ContributionRequestComponent;
  let fixture: ComponentFixture<ContributionRequestComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ContributionRequestComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(ContributionRequestComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
