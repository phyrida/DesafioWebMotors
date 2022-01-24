import { TestBed } from '@angular/core/testing';

import { DesafioServiceService } from './desafio-service.service';

describe('DesafioServiceService', () => {
  let service: DesafioServiceService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(DesafioServiceService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
