import { TestBed } from '@angular/core/testing';

import { BusinessCardService } from './business-card-service.service';

describe('BusinessCardServiceService', () => {
  let service: BusinessCardService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(BusinessCardService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
