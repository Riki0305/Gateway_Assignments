import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-division',
  templateUrl: './division.component.html',
  styleUrls: ['./division.component.css']
})
export class DivisionComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }

  divide(num1, num2)
  {
    if(num2 == 0)
    {
      return "Diveded by 0 exception";
    }
    else
    {
      return num1/num2;
    }
  }
}
