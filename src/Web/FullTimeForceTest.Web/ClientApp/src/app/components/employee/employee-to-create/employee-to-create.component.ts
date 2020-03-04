import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { EmployeeToCreate } from '../../../models/employee-to-create';

@Component({
  selector: 'app-employee-to-create',
  templateUrl: './employee-to-create.component.html',
  styleUrls: ['./employee-to-create.component.css']
})
export class EmployeeToCreateComponent implements OnInit {

  employeeForm: FormGroup;
  employeeToCreate = new EmployeeToCreate();

  constructor(private fb: FormBuilder) { }

  ngOnInit() {

    this.employeeForm = this.fb.group({
      name: ['', [Validators.required]],
      priceHour: [0, [Validators.required]],
      totalHoursWork: [0, [Validators.required]],
      antiquity: [0, [Validators.required]]
    });

  }

  save() {

  }

}
