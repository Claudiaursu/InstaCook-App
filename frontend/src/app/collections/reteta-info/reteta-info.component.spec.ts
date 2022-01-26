import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RetetaInfoComponent } from './reteta-info.component';

describe('RetetaInfoComponent', () => {
  let component: RetetaInfoComponent;
  let fixture: ComponentFixture<RetetaInfoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ RetetaInfoComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(RetetaInfoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
