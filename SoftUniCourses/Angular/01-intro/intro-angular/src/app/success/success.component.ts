import { Component } from "@angular/core";

@Component({
    selector: 'app-success',
    templateUrl: './success.component.html',
    styleUrls: ['./success.component.css'],
})


export class SuccessComponent {
    text: string

    constructor() {
        this.text = "Good job";
    }
}