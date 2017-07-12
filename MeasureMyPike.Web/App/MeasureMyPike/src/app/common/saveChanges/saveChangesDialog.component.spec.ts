import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SaveChangesDialogComponent } from './saveChangesDialog.component';

describe('SaveChangesDialog', () => {
  let component: SaveChangesDialogComponent;
  let fixture: ComponentFixture<SaveChangesDialogComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SaveChangesDialogComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SaveChangesDialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should be created', () => {
    expect(component).toBeTruthy();
  });
});
