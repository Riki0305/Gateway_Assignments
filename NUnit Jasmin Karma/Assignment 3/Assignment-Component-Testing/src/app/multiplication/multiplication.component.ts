import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-multiplication',
  templateUrl: './multiplication.component.html',
  styleUrls: ['./multiplication.component.css']
})
export class MultiplicationComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }

  multiply(num1,num2)
  {
    return num1 * num2;
  }
}
