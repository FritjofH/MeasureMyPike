import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { UserLoginViewComponent } from './userLogin-view.component';

describe('UserViewComponent', () => {
  let component: UserLoginViewComponent;
  let fixture: ComponentFixture<UserLoginViewComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ UserLoginViewComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(UserLoginViewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should be created', () => {
    expect(component).toBeTruthy();
  });
});
