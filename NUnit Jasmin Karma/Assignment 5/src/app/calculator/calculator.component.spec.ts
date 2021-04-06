import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CalculatorComponent } from './calculator.component';

class MockCalculatorService
{
  add(n1, n2)
  {
    return n1 + n2;
  }

  subtract(n1, n2)
  {
    return n1 - n2;
  }

  multiply(n1, n2)
  {
    return n1 * n2;
  }

  divide(n1, n2)
  {
    if(n2 == 0)
    {
      return "Divide by zero exception";
    }
    else
    {
      return n1 / n2;
    }
  }

  power(n1,n2)
  {
    return n1 ^ n2;
  }
}

describe('CalculatorComponent', () => {
let component : CalculatorComponent;
let service : MockCalculatorService;
let spy : any;

beforeEach(()=>{
  service = new MockCalculatorService();
  component = new CalculatorComponent(service);
})

afterEach(()=>{
  component= null;
  service = null;
})

//Add two numbers [Positive case]
it('add two numbers [Positive case]',()=>{
  spy = spyOn(service,'add').and.returnValue(4);
  expect(component.Addition(1,3)).toEqual(4);
})

//Add two numbers [Negative case]
it('add two numbers [Negative case]',()=>{
  spy = spyOn(service,'add').and.returnValue(5);
  expect(component.Addition(1,3)).toEqual(4);
})

 //Subtract two numbers [Positive case]
 it('subtract two numbers [Positive case]',()=>{
  spy = spyOn(service,'subtract').and.returnValue(2);
  expect(component.Subtraction(4,2)).toEqual(2);
})

//Subtract two numbers [Negative case]
it('subtract two numbers [Negative case]',()=>{
  spy = spyOn(service,'subtract').and.returnValue(1);
  expect(component.Subtraction(4,2)).toEqual(2);
})

 //Divide two numbers [Positive case]
 it('divide two numbers [Positive case]',()=>{
  spy = spyOn(service,'divide').and.returnValue(2);
  expect(component.Division(6,3)).toEqual(2);
})

 //Divide two numbers [Negative case]
 it('divide two numbers [Negative case]',()=>{
  spy = spyOn(service,'divide').and.returnValue(4);
  expect(component.Division(6,3)).toEqual(2);
})

 //Multiply two numbers [Positive case]
 it('multiply two numbers [Positive case]',()=>{
  spy = spyOn(service,'multiply').and.returnValue(18);
  expect(component.Multiplication(6,3)).toEqual(18);
})

//Multiply two numbers [Negative case]
it('multiply two numbers [Negative case]',()=>{
  spy = spyOn(service,'multiply').and.returnValue(3);
  expect(component.Multiplication(6,3)).toEqual(18);
})

 //power function [Positive case]
 it('power function [Positive case]',()=>{
  spy = spyOn(service,'power').and.returnValue(8);
  expect(component.Power(2,3)).toEqual(8);
})

//power function [Negative case]
it('power function [Negative case]',()=>{
  spy = spyOn(service,'power').and.returnValue(3);
  expect(component.Power(2,3)).toEqual(8);
})
});
