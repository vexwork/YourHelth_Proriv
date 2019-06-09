import { Component, OnInit } from '@angular/core';
import {UserService} from '../user.service';
import {HttpClient, HttpParams} from '@angular/common/http';
import {User} from '../models/user';


@Component({
  selector: 'app-user-search',
  templateUrl: './user-search.component.html',
  styleUrls: ['./user-search.component.less']
})
export class UserSearchComponent implements OnInit {

  public firstName: string;
  public lastName: string;
  public personalId: string;
  public users = [];

  constructor(public userService: UserService) {

  }

  ngOnInit() {
      this.firstName = '';
      this.lastName = '';
      this.personalId = '';
  }

  searchAction(){
      this.users = [
          {
              guid: '124124124124',
              firstName: 'Vasya',
              lastName: 'dmitriev',
              personalId: '123-124124-123',
          },
          {
              guid: '234234234',
              firstName: 'Vasya 2',
              lastName: 'dmitriev 3',
              personalId: '123-124124-123',
          }
      ];

      //this.userService.findUsers({'firstName': this.firstName, 'lastName': this.lastName, 'personalId': this.personalId }).subscribe(users => this.users = users['patientsItems']);
  }

}
