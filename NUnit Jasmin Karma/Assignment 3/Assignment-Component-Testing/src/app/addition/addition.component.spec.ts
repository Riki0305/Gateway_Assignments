import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AdditionComponent } from './addition.component';

describe('AdditionComponent', () => {
  let component: AdditionComponent;
  let fixture: ComponentFixture<AdditionComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AdditionComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AdditionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  //Positive Test case
    it('should add two numbers',() => {
      //Arrange
      const fixture = TestBed.createComponent(AdditionComponent);

      //Act
      const app = fixture.componentInstance;

      //Assert
      expect(app.add(3,5)).toEqual(8);

    });


  //Negative Test case
    it('should add two numbers negative case',() => {
      //Arrange
      const fixture = TestBed.createComponent(AdditionComponent);

      //Act
      const app = fixture.componentInstance;

      //Assert
      expect(app.add(3,5)).toEqual(10);

    });

});
