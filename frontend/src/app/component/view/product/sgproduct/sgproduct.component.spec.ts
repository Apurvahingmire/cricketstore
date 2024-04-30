import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SgproductComponent } from './sgproduct.component';

describe('SgproductComponent', () => {
  let component: SgproductComponent;
  let fixture: ComponentFixture<SgproductComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [SgproductComponent]
    });
    fixture = TestBed.createComponent(SgproductComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
