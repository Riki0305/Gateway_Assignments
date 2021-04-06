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
}

describe('CalculatorComponent', () => {
  let component: CalculatorComponent;
  let service : MockCalculatorService;

  beforeEach(() => {
    service = new MockCalculatorService();
    component = new CalculatorComponent(service);
  })

  afterEach(() => {
    component =null;
    service = null;
  })

  //Add two numbers [Positive case]
  it('add two numbers [Positive case]',()=>{
    expect(component.Addition(1,3)).toEqual(4);
  })

   //Subtract two numbers [Positive case]
   it('subtract two numbers [Positive case]',()=>{
    expect(component.Subtraction(4,2)).toEqual(2);
  })

   //Divide two numbers [Positive case]
   it('divide two numbers [Positive case]',()=>{
    expect(component.Division(6,3)).toEqual(2);
  })

   //Multiply two numbers [Positive case]
   it('multiply two numbers [Positive case]',()=>{
    expect(component.Multiplication(6,3)).toEqual(18);
  })

});
