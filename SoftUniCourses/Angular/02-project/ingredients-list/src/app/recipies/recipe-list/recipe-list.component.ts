import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { Recipe } from './recepe.model';
import { RecipeService } from '../recipe.service';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-recipe-list',
  templateUrl: './recipe-list.component.html',
  styleUrls: ['./recipe-list.component.css']
})
export class RecipeListComponent implements OnInit {

  recipies: Recipe[];

  constructor(
    private recipeService: RecipeService,
    private router: Router,
    private route: ActivatedRoute) {
  }

  ngOnInit() {
    this.recipies = this.recipeService.GetRecipies();
  }

  onAddNew() {
      this.router.navigate(['add-new-recipe'], { relativeTo: this.route, queryParamsHandling: 'preserve' });
  }
}
