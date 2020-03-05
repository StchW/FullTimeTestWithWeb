import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { EmployeeComponent } from './components/employee/employee.component';
import { StudentComponent } from './components/student/student.component';
import { WordComponent } from './components/word/word.component';
import { EmployeeToCreateComponent } from './components/employee/employee-to-create/employee-to-create.component';
import { WordToCreateComponent } from './components/word/word-to-create/word-to-create.component';


const routes: Routes = [
  { path: "", component: EmployeeComponent },
  { path: "employee", component: EmployeeComponent },
  { path: "employee/:id", component: EmployeeToCreateComponent },
  { path: "student", component: StudentComponent },
  { path: "word", component: WordComponent },
  { path: "word/:id", component: WordToCreateComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
