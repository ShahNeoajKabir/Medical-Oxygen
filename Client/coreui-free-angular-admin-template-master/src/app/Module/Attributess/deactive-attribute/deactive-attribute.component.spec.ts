import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DeactiveAttributeComponent } from './deactive-attribute.component';

describe('DeactiveAttributeComponent', () => {
  let component: DeactiveAttributeComponent;
  let fixture: ComponentFixture<DeactiveAttributeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DeactiveAttributeComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(DeactiveAttributeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
