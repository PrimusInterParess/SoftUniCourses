import { Component, ElementRef, EventEmitter, Output, ViewChild } from '@angular/core';
import { Ingredient } from 'src/app/share/ingredient.model';
import { ShoppingListService } from '../shopping-list.service';

@Component({
  selector: 'app-shopping-edit-list',
  templateUrl: './shopping-edit-list.component.html',
  styleUrls: ['./shopping-edit-list.component.css']
})
export class ShoppingEditListComponent {

  @ViewChild('name', { static: true }) ingredientName: ElementRef;
  @ViewChild('amount', { static: true }) ingredientAmount: ElementRef;

  constructor(private shoppingListService: ShoppingListService) {
  }

  onSubmit() {
    this.shoppingListService.addIngredient(new Ingredient(this.ingredientName.nativeElement.value, this.ingredientAmount.nativeElement.value));
  }
}
