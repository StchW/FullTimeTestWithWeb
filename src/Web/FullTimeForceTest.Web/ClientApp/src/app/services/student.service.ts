import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { NoteToList } from '../models/note-to-list';
import { NoteToCreate } from '../models/note-to-create';
import { BaseService } from './base.service';

@Injectable({
  providedIn: 'root'
})
export class StudentService extends BaseService {

  constructor(private http: HttpClient) {
    super();
  }

  calculate(notes: NoteToCreate): Observable<NoteToList> {
    return this.http.post<NoteToList>(`${this.endpointFulltimeforceApi}/v1/students/calculatefinalnote`, notes);
  }

}
