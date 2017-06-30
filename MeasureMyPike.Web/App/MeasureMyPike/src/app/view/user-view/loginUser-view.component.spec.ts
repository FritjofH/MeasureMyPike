import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { RegisterUserViewComponent } from './registerUser-view.component';

describe('UserViewComponent', () => {
  let component: RegisterUserViewComponent;
  let fixture: ComponentFixture<RegisterUserViewComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ RegisterUserViewComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(RegisterUserViewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should be created', () => {
    expect(component).toBeTruthy();
  });
});
