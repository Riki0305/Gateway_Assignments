import { ComponentFixture, TestBed } from '@angular/core/testing';

import { HelloComponent } from './hello.component';

describe('HelloComponent', () => {
  let component: HelloComponent;
  let fixture: ComponentFixture<HelloComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ HelloComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(HelloComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  //Positive test case
  it('should say hello', () => {
    // Arrange
    const sayHelloSpy = spyOn(component.sendHello, 'emit');
    // Act
    component.sayHello();
    // Assert
    expect(sayHelloSpy).toHaveBeenCalled();
    expect(sayHelloSpy).toHaveBeenCalledWith('Hello');
  });

   //Negative test case
   it('should say hello negative', () => {
    // Arrange
    const sayHelloSpy = spyOn(component.sendHello, 'emit');
    // Act
    component.sayHello();
    // Assert
    expect(sayHelloSpy).toHaveBeenCalled();
    expect(sayHelloSpy).toHaveBeenCalledWith('Bye');
  });
});
