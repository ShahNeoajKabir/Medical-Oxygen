import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DeactiveProductComponent } from './deactive-product.component';

describe('DeactiveProductComponent', () => {
  let component: DeactiveProductComponent;
  let fixture: ComponentFixture<DeactiveProductComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DeactiveProductComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(DeactiveProductComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
