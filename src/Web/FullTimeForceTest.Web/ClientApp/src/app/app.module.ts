import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

import { HttpClientModule } from '@angular/common/http';
import { ReactiveFormsModule } from '@angular/forms';
import { EmployeeComponent } from './components/employee/employee.component';
import { StudentComponent } from './components/student/student.component';
import { WordComponent } from './components/word/word.component';
import { EmployeeToCreateComponent } from './components/employee/employee-to-create/employee-to-create.component';
import { WordToCreateComponent } from './components/word/word-to-create/word-to-create.component';

@NgModule({
  declarations: [
    AppComponent,
    EmployeeComponent,
    StudentComponent,
    WordComponent,
    EmployeeToCreateComponent,
    WordToCreateComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    ReactiveFormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
