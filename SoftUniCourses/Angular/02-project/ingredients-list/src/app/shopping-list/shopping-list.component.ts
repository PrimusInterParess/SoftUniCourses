import { Component, OnDestroy, OnInit } from '@angular/core';
import { Ingredient } from '../share/ingredient.model';
import { ShoppingListService } from './shopping-list.service';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-shopping-list',
  templateUrl: './shopping-list.component.html',
  styleUrls: ['./shopping-list.component.css'],
})
export class ShoppingListComponent implements OnInit,OnDestroy {

  ingredientSubscription:Subscription;

  ingredients: Ingredient[] = [];
  constructor(private shoppingListService: ShoppingListService) {
  }
  ngOnDestroy(): void {
    this.ingredientSubscription.unsubscribe()
  }

  ngOnInit() {
    this.ingredients = this.shoppingListService.getIngredients();
    this.ingredientSubscription= this.shoppingListService.ingredientsUpdated.subscribe((ingredients: Ingredient[]) => (this.ingredients = ingredients));
  }
}
