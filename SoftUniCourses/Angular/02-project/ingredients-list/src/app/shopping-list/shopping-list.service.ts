import { EventEmitter } from "@angular/core";
import { Ingredient } from "../share/ingredient.model";

export class ShoppingListService {

    ingredientsUpdated = new EventEmitter<Ingredient[]>();

    private ingredients: Ingredient[] = [
        new Ingredient('Apples', 20),
        new Ingredient('Tomatos', 10),
    ];

    getIngredients() {
        return this.ingredients.slice();
    }

    addIngredient(ingredient:Ingredient) {
        this.ingredients.push(ingredient);
        this.ingredientsUpdated.emit(this.ingredients.slice());
    }

    addIngredients(ingredients:Ingredient[]){
        
        this.ingredients.push(...ingredients);
        this.ingredientsUpdated.emit(this.ingredients.slice());
    }
}