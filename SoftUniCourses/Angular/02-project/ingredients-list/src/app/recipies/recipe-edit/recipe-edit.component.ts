import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Params } from '@angular/router';
import { RecipeService } from '../recipe.service';
import { Recipe } from '../recipe-list/recepe.model';

@Component({
  selector: 'app-recipe-edit',
  templateUrl: './recipe-edit.component.html',
  styleUrls: ['./recipe-edit.component.css']
})
export class RecipeEditComponent implements OnInit {

  id: number;
  recipe: Recipe;
  editMode: boolean = false;
  constructor(
    private route: ActivatedRoute,
    private recipeService: RecipeService) {
  }

  ngOnInit() {
    this.route.params.subscribe((params: Params) => {

      this.editMode = params['id'] != null;

      if(this.editMode){

        this.id = +params['id'];
        this.recipe = this.recipeService.getRecepe(this.id);
      }
      
    })
  }
}
