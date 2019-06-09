import { Component, OnInit } from '@angular/core';
import {User} from '../models/user';
import {Router} from '@angular/router';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.less']
})
export class RegisterComponent implements OnInit {

    public user:Array<any> = [];

    constructor(
        private router: Router
    ) { }

    ngOnInit() {

    }

    public registerAction(){
        this.router.navigate(['/user-search'])
    }

}
