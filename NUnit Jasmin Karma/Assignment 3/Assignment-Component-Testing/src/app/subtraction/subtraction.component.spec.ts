import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SubtractionComponent } from './subtraction.component';

describe('SubtractionComponent', () => {
  let component: SubtractionComponent;
  let fixture: ComponentFixture<SubtractionComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SubtractionComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SubtractionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  //Positive Test case
  it('should subtract two numbers',() => {
    //Arrange
    const fixture = TestBed.createComponent(SubtractionComponent);

    //Act
    const app = fixture.componentInstance;

    //Assert
    expect(app.subtract(10,5)).toEqual(5);

  })


//Negative Test case
  it('should subtract two numbers negative case',() => {
    //Arrange
    const fixture = TestBed.createComponent(SubtractionComponent);

    //Act
    const app = fixture.componentInstance;

    //Assert
    expect(app.subtract(10,5)).toEqual(10);

  })

});
