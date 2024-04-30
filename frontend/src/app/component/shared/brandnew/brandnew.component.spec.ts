import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BrandnewComponent } from './brandnew.component';

describe('BrandnewComponent', () => {
  let component: BrandnewComponent;
  let fixture: ComponentFixture<BrandnewComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [BrandnewComponent]
    });
    fixture = TestBed.createComponent(BrandnewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
