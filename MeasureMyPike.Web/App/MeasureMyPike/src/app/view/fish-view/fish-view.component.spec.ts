import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { FishViewComponent } from './fish-view.component';

describe('FishViewComponent', () => {
  let component: FishViewComponent;
  let fixture: ComponentFixture<FishViewComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ FishViewComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(FishViewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should be created', () => {
    expect(component).toBeTruthy();
  });
});
