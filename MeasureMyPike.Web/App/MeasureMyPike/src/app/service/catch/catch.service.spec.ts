import { TestBed, inject } from '@angular/core/testing';

import { CatchService } from './catch.service';

describe('CatchService', () => {
    beforeEach(() => {
        TestBed.configureTestingModule({
            providers: [CatchService]
        });
    });

    it('should be created', inject([CatchService], (service: CatchService) => {
        expect(service).toBeTruthy();
    }));
});
