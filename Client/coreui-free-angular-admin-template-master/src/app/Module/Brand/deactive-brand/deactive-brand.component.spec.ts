import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DeactiveBrandComponent } from './deactive-brand.component';

describe('DeactiveBrandComponent', () => {
  let component: DeactiveBrandComponent;
  let fixture: ComponentFixture<DeactiveBrandComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DeactiveBrandComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(DeactiveBrandComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
