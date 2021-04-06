import { Component, OnInit } from '@angular/core';
import { CalculatorService } from './calculator.service';

@Component({
  selector: 'app-calculator',
  templateUrl: './calculator.component.html',
  styleUrls: ['./calculator.component.css']
})
export class CalculatorComponent implements OnInit {

  constructor(private calc : CalculatorService) { }

  ngOnInit(): void {
  }

  Addition(n1, n2)
  {
    return this.calc.add(n1,n2);
  }

  Subtraction(n1, n2)
  {
    return this.calc.subtract(n1,n2);
  }

  Multiplication(n1, n2)
  {
    return this.calc.multiply(n1,n2);
  }

  Division(n1, n2)
  {
    return this.calc.divide(n1,n2);
  }

  Power(n1, n2)
  {
    return this.calc.power(n1,n2);
  }
}
