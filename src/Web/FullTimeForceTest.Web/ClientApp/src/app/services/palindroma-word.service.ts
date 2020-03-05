import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { BaseService } from './base.service';
import { Observable, throwError } from 'rxjs';
import { WordToList } from '../models/word-to-list';
import { WordToEvaluate } from '../models/word-to-evaluate';
import { catchError } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class PalindromaWordService extends BaseService {

  constructor(private http: HttpClient) {
    super();
  }

  save(wordToEvaluate: WordToEvaluate): Observable<WordToList> {
    const headers = new HttpHeaders({ 'Content-Type': 'application/json' });

    return this.http.post<WordToList>(`${this.endpointFulltimeforceApi}/v1/wordspalindroma/evaluatewordpalindroma`, wordToEvaluate, { headers })
      .pipe(
      );
  }

  list(): Observable<WordToList[]> {
    return this.http.get<WordToList[]>(`${this.endpointFulltimeforceApi}/v1/wordspalindroma/listWords`);
  }


}
