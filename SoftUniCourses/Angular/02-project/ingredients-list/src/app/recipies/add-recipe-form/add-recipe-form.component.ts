import { Component, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-add-recipe-form',
  templateUrl: './add-recipe-form.component.html',
  styleUrls: ['./add-recipe-form.component.css']
})
export class AddRecipeFormComponent {
  defaultLevel: string = 'advanced';
  submitted: boolean = false;

  user = {
    email: '',
    password: '',
    level: '',
  };

  onSubmit(f: NgForm) {
    console.log(f.value);
    console.log(f.valid);
    this.submitted=true;
    this.user.email = f.value.userData.email;
    this.user.password = f.value.userData.password;
    this.user.level = f.value.userData.level;
    f.reset();
  }

}
