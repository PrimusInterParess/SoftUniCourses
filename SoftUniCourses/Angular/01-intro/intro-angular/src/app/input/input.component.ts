import { Component } from "@angular/core";

@Component({
    selector:'app-input',
    templateUrl:'./input.component.html',
    styleUrls:['./input.component.css'],
})

export class InputComponent{
    username:string=''
    allowed:boolean=true;
    displayNgf:boolean=false;

    OnReset(){
        this.displayNgf=true;
    }
    //  ResetUser(event:Event) {
    //     this.username=(event.target as HTMLInputElement).value
    //     this.allowed=false;

    // }
}