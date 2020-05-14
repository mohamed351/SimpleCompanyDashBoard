import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { EmpFormsComponent } from './emp-forms.component';

describe('EmpFormsComponent', () => {
  let component: EmpFormsComponent;
  let fixture: ComponentFixture<EmpFormsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ EmpFormsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(EmpFormsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
