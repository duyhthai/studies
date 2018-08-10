import { Component, Inject } from "@angular/core";
import { FormGroup, FormControl, FormBuilder, Validators  } from "@angular/forms";
import { Router } from "@angular/router";
import { HttpClient } from "@angular/common/http";

@Component({
    selector: "register",
    templateUrl: "./register.component.html",
    styleUrls: ['./register.component.css']
})

export class RegisterComponent {
    title: string;
    form: FormGroup;

    constructor(
        private router: Router,
        private fb: FormBuilder,
        private http: HttpClient,
        @Inject('BASE_URL') private baseUrl: string) {

        this.title = "New User Registration";
    }
}