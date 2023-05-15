import { Ingredient } from "../share/ingredient.model";
import { Subject } from 'rxjs';

export class ShoppingListService {

    ingredientsUpdated = new Subject<Ingredient[]>();

    private ingredients: Ingredient[] = [
        new Ingredient('Apples', 20),
        new Ingredient('Tomatos', 10),
    ];

    getIngredients() {
        return this.ingredients.slice();
    }

    addIngredient(ingredient: Ingredient) {
        this.ingredients.push(ingredient);
        this.ingredientsUpdated.next(this.ingredients.slice());
    }

    addIngredients(ingredients: Ingredient[]) {

        this.ingredients.push(...ingredients);
        this.ingredientsUpdated.next(this.ingredients.slice());
    }
}