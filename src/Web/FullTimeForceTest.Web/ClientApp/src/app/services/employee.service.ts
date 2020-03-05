import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { BaseService } from './base.service';
import { Observable, throwError } from 'rxjs';
import { EmployeeToCreate } from '../models/employee-to-create';
import { catchError } from 'rxjs/operators';
import { EmployeeToList } from '../models/employee-to-list';

@Injectable({
  providedIn: 'root'
})
export class EmployeeService extends BaseService {

  constructor(private http: HttpClient) {
      super();
  }


  saveEmployeeCalculateSalary(employee: EmployeeToCreate): Observable<EmployeeToList> {
    const headers = new HttpHeaders({ 'Content-Type': 'application/json' });
    employee.id = null;

    return this.http.post<EmployeeToList>(`${this.endpointFulltimeforceApi}/v1/employees/calculatesalary`, employee, { headers })
      .pipe(
        catchError(this.handleError)
      );
  }

  listSalaries(): Observable<EmployeeToList[]> {
    return this.http.get<EmployeeToList[]>(`${this.endpointFulltimeforceApi}/v1/employees/listsalaries`)
      .pipe(
        catchError(this.handleError)
      );
  }

  private handleError(err) {
    let errorMessage: string;
    if (err.error instanceof ErrorEvent) {
      errorMessage = `An error occurred: ${err.error.message}`;
    } else {
      errorMessage = `Backend returned code ${err.status}: ${err.body.error}`;
    }
    console.error(err);
    return throwError(errorMessage);
  }



}
