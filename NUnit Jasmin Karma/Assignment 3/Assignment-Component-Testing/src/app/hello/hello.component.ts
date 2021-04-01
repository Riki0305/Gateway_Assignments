import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';


@Component({
  selector: 'app-hello',
  templateUrl: './hello.component.html',
  styleUrls: ['./hello.component.css']
})
export class HelloComponent implements OnInit {

  @Input() name : string;
  @Output() sendHello = new EventEmitter<string>();

  constructor() { }

  ngOnInit(): void {
  }

  sayHello()
  {
    this.sendHello.emit('Hello');
  }


}
