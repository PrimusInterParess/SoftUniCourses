import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ShoppingEditListComponent } from './shopping-edit-list.component';

describe('ShoppingEditListComponent', () => {
  let component: ShoppingEditListComponent;
  let fixture: ComponentFixture<ShoppingEditListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ShoppingEditListComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ShoppingEditListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
