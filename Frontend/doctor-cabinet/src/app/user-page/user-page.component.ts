import {Component, ComponentFactoryResolver, OnInit, ViewChild, ViewContainerRef} from '@angular/core';
import {User} from '../models/user';
import {UserService} from '../user.service';
import {ActivatedRoute} from '@angular/router';
@Component({
    selector: 'app-user-page',
    templateUrl: './user-page.component.html',
    styleUrls: ['./user-page.component.less']
})
export class UserPageComponent implements OnInit {
    public user: User = new User();
    public userid: string;
    public therapyFormShow = false;
    public answerText:any;

    submittedTherapy = false;
    therapyForm: FormGroup;
    prescriptions: FormArray;

    constructor(public userService: UserService,
                public route: ActivatedRoute,
                private formBuilder: FormBuilder,
                private resolver:ComponentFactoryResolver) { }
/*
    public toggleTime = {

        1: false,
        2: false,
        3: false,
    };
*/
    ngOnInit() {
        this.userid = this.route.snapshot.paramMap.get('id');
        console.log(this.userid);
        // получение данных юзера
        // this.userService.getUser(this.id).subscribe(users => this.users = users['patientsprescriptions']);
        this.therapyForm = this.formBuilder.group({
            prescriptions: this.formBuilder.array([ this.createItem() ])
        });
    }

    createItem(): FormGroup {
        return this.formBuilder.group({
            name: ['', Validators.required],
            type: 1,
            duration: ['', Validators.required],
            period: 0,
            time: '',//this.createTimes()
        });
    }
    //
    // createTimes(): FormGroup {
    //     return this.formBuilder.group({
    //         time: ['', Validators.required]
    //     });
    // }
    //
    // addTimes(id: void {
    //     this.time = this.therapyForm.get('prescriptions')[id].get('time') as FormArray;
    //     this.time.push(this.createTimeItem());
    // }

    addItem(): void {
        this.prescriptions = this.therapyForm.get('prescriptions') as FormArray;
        this.prescriptions.push(this.createItem());
    }

    /*

    Назанчение на лечение

    toggleTimeChange(id) {
        let i = 1;
        while (i <= 3) {
            this.toggleTime[i] = false;
            i++;
        }
        i = 1;
        while (i <= id) {
            this.toggleTime[i] = true;
            i++;
        }
    }

    */

    therapyFormAction() {
        //Отправка формы
        let serializedForm = JSON.stringify(this.therapyForm.getRawValue());
        console.log(serializedForm);
        this.submittedTherapy = true;
        // stop here if form is invalid
        if (this.therapyForm.invalid) {
            console.log("errors");
            return false;
        }
        else {
            console.log("success submit");
            //this.userService.sendReception({ "type":this.type, }).subscribe(answer => this.answerText = answer);
            //this.receptionFormShow = false;
        }
    }



    toggleTherapyForm() {
        this.therapyFormShow = !this.therapyFormShow;
    }
    //
    // toggleReceptionForm() {
    //     this.receptionFormShow = !this.receptionFormShow;
    // }

    therapyFormCancel(){
        this.therapyFormShow = false;
    }
    //
    // receptionFormCancel(){
    //     this.receptionFormShow = false;
    // }

}

import {FormBuilder, Validators, ReactiveFormsModule, FormGroup, FormArray} from '@angular/forms';
