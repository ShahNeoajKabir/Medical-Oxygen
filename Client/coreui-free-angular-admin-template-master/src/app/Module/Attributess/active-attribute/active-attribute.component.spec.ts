import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ActiveAttributeComponent } from './active-attribute.component';

describe('ActiveAttributeComponent', () => {
  let component: ActiveAttributeComponent;
  let fixture: ComponentFixture<ActiveAttributeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ActiveAttributeComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ActiveAttributeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
