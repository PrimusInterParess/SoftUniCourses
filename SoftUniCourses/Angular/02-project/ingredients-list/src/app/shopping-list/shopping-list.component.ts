import { Component } from '@angular/core';
import { Ingredient } from '../share/ingredient.model';

@Component({
  selector: 'app-shopping-list',
  templateUrl: './shopping-list.component.html',
  styleUrls: ['./shopping-list.component.css'],
})
export class ShoppingListComponent {
  ingredients: Ingredient[] = [
    new Ingredient('Apples', 20),
    new Ingredient('Tomatos', 10),
  ];

  ingredientAdded(newIngredient: Ingredient) {
    this.ingredients.push(newIngredient);
  }
}
