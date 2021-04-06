import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class CalculatorService {

  constructor() { }

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
