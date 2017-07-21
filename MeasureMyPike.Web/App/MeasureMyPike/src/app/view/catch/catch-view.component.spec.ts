import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CatchViewComponent } from './catch-view.component';

describe('CatchViewComponent', () => {
    let component: CatchViewComponent;
    let fixture: ComponentFixture<CatchViewComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
        declarations: [CatchViewComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
      fixture = TestBed.createComponent(CatchViewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should be created', () => {
    expect(component).toBeTruthy();
  });
});
