import { Component, OnInit } from '@angular/core';
import { PalindromaWordService } from '../../services/palindroma-word.service';
import { WordToList } from '../../models/word-to-list';

@Component({
  selector: 'app-word',
  templateUrl: './word.component.html',
  styleUrls: ['./word.component.css']
})
export class WordComponent implements OnInit {

  words: WordToList[] = [];

  constructor(private palindromaWordService: PalindromaWordService) { }

  ngOnInit() {
    this.palindromaWordService.list().subscribe({
      next: wordsResult => this.words = wordsResult
    });
  }

}
