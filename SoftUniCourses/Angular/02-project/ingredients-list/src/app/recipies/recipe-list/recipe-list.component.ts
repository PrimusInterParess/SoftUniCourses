import { Component } from '@angular/core';
import { Recipe } from './recepe.model';

@Component({
  selector: 'app-recipe-list',
  templateUrl: './recipe-list.component.html',
  styleUrls: ['./recipe-list.component.css']
})
export class RecipeListComponent {
  recepies: Recipe[] = [new Recipe('test','test descr','https://img.freepik.com/free-photo/top-view-table-full-delicious-food-composition_23-2149141353.jpg')];
}
