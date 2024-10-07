import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PreviewBusinessCardComponent } from './preview-business-card.component';

describe('PreviewBusinessCardComponent', () => {
  let component: PreviewBusinessCardComponent;
  let fixture: ComponentFixture<PreviewBusinessCardComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [PreviewBusinessCardComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(PreviewBusinessCardComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
