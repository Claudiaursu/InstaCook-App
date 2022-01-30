import { TestBed } from '@angular/core/testing';

import { CollectiiResponseInterceptor } from './colectii-response.interceptor';

describe('CollectiiResponseInterceptor', () => {
  beforeEach(() => TestBed.configureTestingModule({
    providers: [
      CollectiiResponseInterceptor
      ]
  }));

  it('should be created', () => {
    const interceptor: CollectiiResponseInterceptor = TestBed.inject(CollectiiResponseInterceptor);
    expect(interceptor).toBeTruthy();
  });
});
