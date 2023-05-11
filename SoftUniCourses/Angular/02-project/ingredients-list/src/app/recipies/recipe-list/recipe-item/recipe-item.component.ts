import { Component, EventEmitter, Input, Output } from '@angular/core';
import { Recipe } from '../recepe.model';
import { RecipeService } from '../../recipe.service';

@Component({
  selector: 'app-recipe-item',
  templateUrl: './recipe-item.component.html',
  styleUrls: ['./recipe-item.component.css']
})
export class RecipeItemComponent {
  @Input() recipe: Recipe;

  constructor(private recipeService: RecipeService) {
  }

  onRecipeClick() {
    this.recipeService.recipeClicked.emit(this.recipe);
  }
}
