import { NgModule } from "@angular/core";
import { RecipiesComponent } from "./recipies/recipies.component";
import { ShoppingListComponent } from "./shopping-list/shopping-list.component";
import { RouterModule, Routes } from "@angular/router";
import { RecipeStartComponent } from "./recipies/recipe-start/recipe-start.component";
import { RecipeDetailsComponent } from "./recipies/recipe-details/recipe-details.component";
import { RecipeEditComponent } from "./recipies/recipe-edit/recipe-edit.component";
import { AddRecipeFormComponent } from "./recipies/add-recipe-form/add-recipe-form.component";

const appRoutes: Routes = [
    { path: '', redirectTo: 'recipies', pathMatch: 'full' },
    { path: 'shopping-list', component: ShoppingListComponent },
    {
        path: 'recipies', component: RecipiesComponent, children: [
            {
                path: '', component: RecipeStartComponent,
            },
            {
                path: 'add-new-recipe', component: AddRecipeFormComponent,
            },
            {
                path: 'new', component: RecipeEditComponent,
            },
            {
                path: ':id', component: RecipeDetailsComponent,
            },
            {
                path: ':id/edit', component: RecipeEditComponent,
            },
        ]
    },
];

@NgModule({
    imports: [
        RouterModule.forRoot(appRoutes),
    ],
    exports: [RouterModule],
})

export class AppRoutingModule { }