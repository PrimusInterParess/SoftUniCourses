import { Component, ElementRef, EventEmitter, Output, ViewChild } from '@angular/core';
import { Ingredient } from 'src/app/share/ingredient.model';
import { ShoppingListService } from '../shopping-list.service';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-shopping-edit-list',
  templateUrl: './shopping-edit-list.component.html',
  styleUrls: ['./shopping-edit-list.component.css']
})
export class ShoppingEditListComponent {

  @ViewChild('ingredientForm', { static: true }) ingredientForm: NgForm;

  constructor(private shoppingListService: ShoppingListService) {
  }

  onSubmit() {
    this.shoppingListService.addIngredient(new Ingredient(this.ingredientForm.value.name, this.ingredientForm.value.amount));
  }
}
