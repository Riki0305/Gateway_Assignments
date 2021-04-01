import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-subtraction',
  templateUrl: './subtraction.component.html',
  styleUrls: ['./subtraction.component.css']
})
export class SubtractionComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }

  subtract(num1,num2)
  {
    return num1 - num2;
  }
}
