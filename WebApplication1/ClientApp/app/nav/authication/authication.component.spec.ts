import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AuthicationComponent } from './authication.component';

describe('AuthicationComponent', () => {
  let component: AuthicationComponent;
  let fixture: ComponentFixture<AuthicationComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AuthicationComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AuthicationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
