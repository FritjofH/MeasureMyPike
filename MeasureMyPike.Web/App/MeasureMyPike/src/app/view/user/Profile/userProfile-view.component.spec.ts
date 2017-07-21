import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { UserProfileViewComponent } from './userProfile-view.component';

describe('UserViewComponent', () => {
    let component: UserProfileViewComponent;
  let fixture: ComponentFixture<UserProfileViewComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
        declarations: [UserProfileViewComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
      fixture = TestBed.createComponent(UserProfileViewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should be created', () => {
    expect(component).toBeTruthy();
  });
});
