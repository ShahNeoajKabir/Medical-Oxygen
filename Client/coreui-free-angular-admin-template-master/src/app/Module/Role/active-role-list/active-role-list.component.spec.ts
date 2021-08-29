import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ActiveRoleListComponent } from './active-role-list.component';

describe('ActiveRoleListComponent', () => {
  let component: ActiveRoleListComponent;
  let fixture: ComponentFixture<ActiveRoleListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ActiveRoleListComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ActiveRoleListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
