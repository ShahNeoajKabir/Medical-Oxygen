import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ActiveCategoriesComponent } from './active-categories.component';

describe('ActiveCategoriesComponent', () => {
  let component: ActiveCategoriesComponent;
  let fixture: ComponentFixture<ActiveCategoriesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ActiveCategoriesComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ActiveCategoriesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
