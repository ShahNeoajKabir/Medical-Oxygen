import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CustomerlisComponent } from './customerlis.component';

describe('CustomerlisComponent', () => {
  let component: CustomerlisComponent;
  let fixture: ComponentFixture<CustomerlisComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CustomerlisComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CustomerlisComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
