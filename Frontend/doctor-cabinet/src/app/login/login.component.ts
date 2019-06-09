import { Component, OnInit } from '@angular/core';
import { User } from '../models/user';
import {Router} from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.less']
})

export class LoginComponent implements OnInit {

    public user:Array<any> = [];

  constructor(
      private router: Router
  ) { }

  ngOnInit() {

  }


  public loginAction(){
    this.router.navigate(['/user-search'])
  }

}
