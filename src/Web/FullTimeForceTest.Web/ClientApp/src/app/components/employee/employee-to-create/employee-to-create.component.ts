import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { EmployeeToCreate } from '../../../models/employee-to-create';
import { Router } from '@angular/router';
import { EmployeeService } from '../../../services/employee.service';
import { EmployeeToList } from '../../../models/employee-to-list';

@Component({
  selector: 'app-employee-to-create',
  templateUrl: './employee-to-create.component.html',
  styleUrls: ['./employee-to-create.component.css']
})
export class EmployeeToCreateComponent implements OnInit {

  employeeForm: FormGroup;
  employeeToCreate = new EmployeeToCreate();
  pageTitle = 'Product Edit';
  errorMessage: string;
  employeeToList = new EmployeeToList();

  constructor(
    private fb: FormBuilder,
    private router: Router,
    private employeeService: EmployeeService) { }

  ngOnInit() {

    this.employeeForm = this.fb.group({
      name: ['', [Validators.required]],
      priceHour: [0, [Validators.required]],
      totalHoursWork: [0, [Validators.required]],
      antiquity: [0, [Validators.required]]
    });

  }

  save(): void {
    if (this.employeeForm.valid) {
      if (this.employeeForm.dirty) {
        const p = { ...this.employeeToCreate, ...this.employeeForm.value };

        this.employeeService.saveEmployeeCalculateSalary(p)
          .subscribe({
            next: reportSalary => this.activateReport(reportSalary),
            error: err => this.errorMessage = err
          });

      } else {
        this.onSaveComplete();
      }
    } else {
      this.errorMessage = 'Please correct the validation errors.';
    }
  }

  activateReport(reportSalary: EmployeeToList): void {
    this.employeeToList = reportSalary;
    console.log(JSON.stringify(reportSalary));
  }

  onSaveComplete(): void {
    // Reset the form to clear the flags
    this.employeeForm.reset();
    this.router.navigate(['/employee']);
  }

  resetForm(): void {
    this.employeeToList.id = 0;
    this.employeeToList.name = '';
    this.employeeToList.antiquity = 0;
    this.employeeToList.netoPayment = 0;
    this.employeeToList.priceHour = 0;
    this.employeeToList.totalDiscounts = 0;
    this.employeeToList.totalGrossCharge = 0;
    this.employeeToList.totalHoursWork = 0;
    this.employeeForm.reset();
  }

}
