import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { EmployeeComponent } from './components/employee/employee.component';
import { StudentComponent } from './components/student/student.component';
import { WordComponent } from './components/word/word.component';


const routes: Routes = [
  { path: "employee", component: EmployeeComponent },
  { path: "student", component: StudentComponent },
  { path: "word", component: WordComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
