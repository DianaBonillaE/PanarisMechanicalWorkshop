import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { VehicleInsertComponent } from './vehicle-insert.component';

describe('VehicleInsertComponent', () => {
  let component: VehicleInsertComponent;
  let fixture: ComponentFixture<VehicleInsertComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ VehicleInsertComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(VehicleInsertComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
