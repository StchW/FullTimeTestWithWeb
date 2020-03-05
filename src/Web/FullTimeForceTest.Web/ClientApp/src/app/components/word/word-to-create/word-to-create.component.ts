import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { WordToEvaluate } from '../../../models/word-to-evaluate';
import { WordToList } from '../../../models/word-to-list';
import { PalindromaWordService } from '../../../services/palindroma-word.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-word-to-create',
  templateUrl: './word-to-create.component.html',
  styleUrls: ['./word-to-create.component.css']
})
export class WordToCreateComponent implements OnInit {

  wordForm: FormGroup;
  wordToEvaluate = new WordToEvaluate();
  wordToList = new WordToList();
  isInEvaluation: boolean = true;

  constructor(
    private fb: FormBuilder,
    private palindromaWordService: PalindromaWordService,
    private router: Router) {

  }

  ngOnInit() {

    this.wordForm = this.fb.group({
      message: ['', [Validators.required]]
    });

    this.wordForm.get('message').valueChanges.subscribe(value => {
      this.isInEvaluation = true;
    });
  }

  save(): void {
    if (this.wordForm.valid) {
      if (this.wordForm.dirty) {
        const p = { ...this.wordToEvaluate, ...this.wordForm.value };

        this.palindromaWordService.save(p)
          .subscribe({
            next: wordResult => {
              this.wordToList = wordResult;
              this.isInEvaluation = false;
            }
          });

      } else {
        this.onSaveComplete();
      }
    }

  }

  onSaveComplete(): void {
    this.wordForm.reset();
    this.router.navigate(['/word']);
  }

  reset(): void {
    this.wordForm.reset();
  }

}
