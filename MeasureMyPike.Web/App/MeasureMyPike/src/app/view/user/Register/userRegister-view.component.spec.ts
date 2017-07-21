import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { UserRegisterViewComponent } from './userRegister-view.component';

describe('UserViewComponent', () => {
  let component: UserRegisterViewComponent;
  let fixture: ComponentFixture<UserRegisterViewComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ UserRegisterViewComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(UserRegisterViewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should be created', () => {
    expect(component).toBeTruthy();
  });
});
