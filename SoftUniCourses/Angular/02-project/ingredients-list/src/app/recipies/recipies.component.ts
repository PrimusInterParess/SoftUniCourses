import { Component, Input, OnChanges, OnInit, SimpleChanges } from '@angular/core';
import { Recipe } from './recipe-list/recepe.model';
import { RecipeService } from './recipe.service';

@Component({
  selector: 'app-recipies',
  templateUrl: './recipies.component.html',
  styleUrls: ['./recipies.component.css'],
  providers: [RecipeService]
})
export class RecipiesComponent implements OnInit{
  currentRecipe:Recipe;

  constructor(private recipeService: RecipeService) {
    
  }

  ngOnInit(){
    this.recipeService.recipeClicked.subscribe((recipe:Recipe)=>{
      this.currentRecipe=recipe;
    })
  }
}
