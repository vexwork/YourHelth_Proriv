import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import {RouterModule,Routes} from '@angular/router';
import { PageNotFoundComponent } from './page-not-found/page-not-found.component';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { UserSearchComponent } from './user-search/user-search.component';
import { UserPageComponent } from './user-page/user-page.component';
import {FormsModule, NgForm, NgModel, ReactiveFormsModule} from '@angular/forms';
import {HttpClientModule} from '@angular/common/http';

const appRoutes: Routes = [
    { path: 'user-search', component: UserSearchComponent },
    { path: 'user/:id',
        component: UserPageComponent,
        // canDeactivate: [ UserFormDeactivateGuard ]
    },
    { path: 'login', component: LoginComponent },
    { path: 'register', component: RegisterComponent },
    {
        path: 'user',
        component: UserPageComponent,
        data: { title: 'Задачи для пользвателя' }
    },
    { path: '',
        redirectTo: '/user-search',
        pathMatch: 'full'
    },
    { path: '**', component: PageNotFoundComponent }
];

@NgModule({
  declarations: [
    AppComponent,
    PageNotFoundComponent,
    LoginComponent,
    RegisterComponent,
    UserSearchComponent,
    UserPageComponent
  ],
  imports: [
    BrowserModule,
      FormsModule,
      HttpClientModule,
      ReactiveFormsModule,
      RouterModule.forRoot(appRoutes)
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
