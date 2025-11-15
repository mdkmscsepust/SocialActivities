import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ReceiveItemComponent } from './receive-item.component';

describe('ReceiveItemComponent', () => {
  let component: ReceiveItemComponent;
  let fixture: ComponentFixture<ReceiveItemComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ReceiveItemComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ReceiveItemComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
