import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MultiplicationComponent } from './multiplication.component';

describe('MultiplicationComponent', () => {
  let component: MultiplicationComponent;
  let fixture: ComponentFixture<MultiplicationComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ MultiplicationComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(MultiplicationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

   //Positive Test case
   it('should multiply two numbers',() => {
    //Arrange
    const fixture = TestBed.createComponent(MultiplicationComponent);

    //Act
    const app = fixture.componentInstance;

    //Assert
    expect(app.multiply(3,5)).toEqual(15);

  })


//Negative Test case
  it('should multiply two numbers negative case',() => {
    //Arrange
    const fixture = TestBed.createComponent(MultiplicationComponent);

    //Act
    const app = fixture.componentInstance;

    //Assert
    expect(app.multiply(3,5)).toEqual(10);

  })
});
