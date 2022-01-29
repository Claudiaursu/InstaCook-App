import { TestBed } from '@angular/core/testing';

import { ExitPermissionGuard } from './exit-permission.guard';

describe('ExitPermissionGuard', () => {
  let guard: ExitPermissionGuard;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    guard = TestBed.inject(ExitPermissionGuard);
  });

  it('should be created', () => {
    expect(guard).toBeTruthy();
  });
});
