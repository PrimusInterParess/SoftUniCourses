import { Component, Input } from '@angular/core';
import { Recipe } from './recipe-list/recepe.model';

@Component({
  selector: 'app-recipies',
  templateUrl: './recipies.component.html',
  styleUrls: ['./recipies.component.css']
})
export class RecipiesComponent {
  currentClicked:Recipe;

  currentlyClicked(currentRecipe:Recipe){
    this.currentClicked=currentRecipe;
    console.log(this.currentClicked);
  }
}
