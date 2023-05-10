import { Component, ElementRef, EventEmitter, Output, ViewChild } from '@angular/core';
import { Ingredient } from 'src/app/share/ingredient.model';

@Component({
  selector: 'app-shopping-edit-list',
  templateUrl: './shopping-edit-list.component.html',
  styleUrls: ['./shopping-edit-list.component.css']
})
export class ShoppingEditListComponent {
  @ViewChild('name', { static: true }) ingredientName: ElementRef;
  @ViewChild('amount', { static: true }) ingredientAmount: ElementRef;

  @Output() ingredientAdd = new EventEmitter<Ingredient>()

  name: string;
  amount: number;

  onSubmit() {
    this.name = this.ingredientName.nativeElement.value;
    this.amount = this.ingredientAmount.nativeElement.value;

    this.ingredientAdd.emit(new Ingredient(this.name, this.amount));
  }
}
