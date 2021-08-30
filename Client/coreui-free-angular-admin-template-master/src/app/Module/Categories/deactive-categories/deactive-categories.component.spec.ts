import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DeactiveCategoriesComponent } from './deactive-categories.component';

describe('DeactiveCategoriesComponent', () => {
  let component: DeactiveCategoriesComponent;
  let fixture: ComponentFixture<DeactiveCategoriesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DeactiveCategoriesComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(DeactiveCategoriesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
