import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
})
export class AppComponent {
  title = 'data-binding-assignment';
  @Input() oddNumbers: number[] = [];
  @Input() evenNumbers: number[] = [];

  onGameStarted(inputData: { currentInterval: number }) {
    if (inputData.currentInterval % 2 === 0) {
      this.evenNumbers.push(inputData.currentInterval);
    } else {
      this.oddNumbers.push(inputData.currentInterval);
    }
  }
}
