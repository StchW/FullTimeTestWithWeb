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
        //catchError(this.handleError)
      );
  }

  //private handleError(err) {
  //  let errorMessage: string;
  //  if (err.error instanceof ErrorEvent) {
  //    errorMessage = `An error occurred: ${err.error.message}`;
  //  } else {
  //    errorMessage = `Backend returned code ${err.status}: ${err.body.error}`;
  //  }
  //  console.error(err);
  //  return throwError(errorMessage);
  //}


}
