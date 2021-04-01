import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DivisionComponent } from './division.component';

describe('DivisionComponent', () => {
  let component: DivisionComponent;
  let fixture: ComponentFixture<DivisionComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DivisionComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(DivisionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  //Positive division test
  it('should divide two number',() =>{
    //Arrange
    const fixture = TestBed.createComponent(DivisionComponent);

    //Act
    const app = fixture.componentInstance;

    //Assert
    expect(app.divide(10,5)).toEqual(2);
  });

  //Divided by 0 exception
  it('should give divide by 0 exception',() =>{
    //Arrange
    const fixture = TestBed.createComponent(DivisionComponent);

    //Act
    const app = fixture.componentInstance;

    //Assert
    expect(app.divide(10,0)).toEqual('Diveded by 0 exception');
  });

   //Negative division test
  it('should divide two number negative case',() =>{
    //Arrange
    const fixture = TestBed.createComponent(DivisionComponent);

    //Act
    const app = fixture.componentInstance;

    //Assert
    expect(app.divide(10,5)).toEqual(5);
  });
});
