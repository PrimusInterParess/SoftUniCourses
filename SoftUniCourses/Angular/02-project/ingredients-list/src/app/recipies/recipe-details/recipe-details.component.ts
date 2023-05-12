import { Component, Input, OnInit } from '@angular/core';
import { Recipe } from '../recipe-list/recepe.model';
import { RecipeService } from '../recipe.service';
import { ActivatedRoute, Params } from '@angular/router';

@Component({
  selector: 'app-recipe-details',
  templateUrl: './recipe-details.component.html',
  styleUrls: ['./recipe-details.component.css']
})
export class RecipeDetailsComponent implements OnInit {
  recipe: Recipe;
  id: number;

  constructor(private recipeService: RecipeService,
    private route: ActivatedRoute
  ) { }
  ngOnInit(): void {
    this.route.params.subscribe((params: Params) => {
      this.id = +params['id'];
      this.recipe= this.recipeService.getRecepe(this.id);
    })
  }

  addToShoppingList() {
    this.recipeService.AddIngredientsToShoppingList(this.recipe.ingredients);
  }
}
