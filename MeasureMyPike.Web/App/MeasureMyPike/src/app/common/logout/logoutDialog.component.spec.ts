import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { LogoutDialogComponent } from './logoutDialog.component';

describe('LogoutDialogComponent', () => {
  let component: LogoutDialogComponent;
  let fixture: ComponentFixture<LogoutDialogComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ LogoutDialogComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(LogoutDialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should be created', () => {
    expect(component).toBeTruthy();
  });
});
