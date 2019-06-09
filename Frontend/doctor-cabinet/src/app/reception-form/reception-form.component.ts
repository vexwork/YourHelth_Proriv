import { Component, OnInit } from '@angular/core';
import {FormBuilder, FormGroup, Validators} from '@angular/forms';
import {ActivatedRoute} from '@angular/router';
import {UserService} from '../user.service';

@Component({
  selector: 'app-reception-form',
  templateUrl: './reception-form.component.html',
  styleUrls: ['./reception-form.component.less']
})
export class ReceptionFormComponent implements OnInit {
    submittedReception = false;
    receptionForm: FormGroup;

  constructor(public userService: UserService,
              public route: ActivatedRoute,
              private formBuilder: FormBuilder) { }


  ngOnInit() {

      this.receptionForm = this.formBuilder.group({
          date: ['', Validators.required],
          text: ['', Validators.required],
      });

  }

  get f() { return this.receptionForm.controls; }

  receptionFormAction(){
      //Отправка формы
      this.submittedReception = true;
      // stop here if form is invalid
      if (this.receptionForm.invalid) {
          return;
      }
      else {
          console.log("success submit");
          //this.userService.sendReception({ "type":this.type, }).subscribe(answer => this.answerText = answer);
          //this.receptionFormShow = false;
      }
  }

}
