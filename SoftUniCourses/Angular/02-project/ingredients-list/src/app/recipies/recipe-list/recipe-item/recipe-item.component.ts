import { Component, EventEmitter, Input, Output } from '@angular/core';
import { Recipe } from '../recepe.model';

@Component({
  selector: 'app-recipe-item',
  templateUrl: './recipe-item.component.html',
  styleUrls: ['./recipe-item.component.css']
})
export class RecipeItemComponent {

  @Output() recipeClicked = new EventEmitter<Recipe>();
  @Input() recipe: Recipe;

  onRecipeClick() {
    this.recipeClicked.emit(this.recipe);
  }
}
