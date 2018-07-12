import { TestBed, inject } from '@angular/core/testing';

import { VehicleRegisterService } from './vehicle-register.service';

describe('VehicleRegisterService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [VehicleRegisterService]
    });
  });

  it('should be created', inject([VehicleRegisterService], (service: VehicleRegisterService) => {
    expect(service).toBeTruthy();
  }));
});
