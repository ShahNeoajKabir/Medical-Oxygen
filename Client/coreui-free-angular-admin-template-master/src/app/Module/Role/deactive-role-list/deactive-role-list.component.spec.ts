import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DeactiveRoleListComponent } from './deactive-role-list.component';

describe('DeactiveRoleListComponent', () => {
  let component: DeactiveRoleListComponent;
  let fixture: ComponentFixture<DeactiveRoleListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DeactiveRoleListComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(DeactiveRoleListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
