import { Component, OnInit } from '@angular/core';
import { StudentService } from '../../services/student.service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { NoteToCreate } from '../../models/note-to-create';
import { NoteToList } from '../../models/note-to-list';

@Component({
  selector: 'app-student',
  templateUrl: './student.component.html',
  styleUrls: ['./student.component.css']
})
export class StudentComponent implements OnInit {

  studentForm: FormGroup;
  noteToCreate = new NoteToCreate();
  noteToList = new NoteToList();

  constructor(
    private fb: FormBuilder,
    private studentService: StudentService) { }

  ngOnInit() {
    this.studentForm = this.fb.group({
      notes: ['', [Validators.required]]
    });
  }

  calculate(): void {
    if (this.studentForm.valid) {
      if (this.studentForm.dirty) {
        const p = { ...this.noteToCreate, ...this.studentForm.value };

        this.studentService.calculate(p)
          .subscribe({
            next: response => this.activateReport(response),
          });

      }
    }
  }

  activateReport(response: NoteToList): void {
    this.noteToList.totalApproved = response.totalApproved;
    this.noteToList.averageNoteApproved = response.averageNoteApproved;
    this.noteToList.totalNotApproved = response.totalNotApproved;
    this.noteToList.averageNoteNotApproved = response.averageNoteNotApproved;
    this.noteToList.averageNoteGeneral = response.averageNoteGeneral;
  }

  resetForm(): void {
    this.studentForm.reset();
  }

}
