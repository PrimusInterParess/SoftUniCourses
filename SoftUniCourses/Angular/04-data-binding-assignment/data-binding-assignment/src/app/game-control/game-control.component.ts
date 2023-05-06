import { Component, EventEmitter, Input, Output } from '@angular/core';

@Component({
  selector: 'app-game-control',
  templateUrl: './game-control.component.html',
  styleUrls: ['./game-control.component.css'],
})
export class GameControlComponent {
  @Output() onGameStart = new EventEmitter<{ currentInterval: number }>();
  increment: number = 1;
  interval: any = 0;

  onStart() {
    this.interval = setInterval(() => this.incrementNumber(), 1000);
  }

  incrementNumber() {
    this.increment = ++this.increment;
    this.onGameStart.emit({
      currentInterval: this.increment,
    });
  }

  onStop() {
    clearInterval(this.interval);
  }
}
