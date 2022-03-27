import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DepartmentCategoryComponent } from './department-category.component';

describe('DepartmentCategoryComponent', () => {
  let component: DepartmentCategoryComponent;
  let fixture: ComponentFixture<DepartmentCategoryComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DepartmentCategoryComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(DepartmentCategoryComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
