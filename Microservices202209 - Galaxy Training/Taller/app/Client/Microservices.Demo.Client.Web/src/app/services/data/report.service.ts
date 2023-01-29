import { Injectable, Inject } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { IReport } from '../../models/ireport';
import { map, catchError } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class ReportService {
  port = '44399';
  //baseUrl = `${this.window.location.protocol}//${this.window.location.hostname}:${this.port}`;
  baseUrl = `http://${this.window.location.hostname}:${this.port}`;
  reportApiUrl = this.baseUrl + '/api/report';

  constructor(
    private http: HttpClient,
    @Inject('Window') private window: Window
  ) { }

  getPolicys(): Observable<IReport[]> {
    return this.http.get<IReport[]>(this.reportApiUrl)
      .pipe(catchError(this.handleError));
  }

  private handleError(error: HttpErrorResponse) {
    console.error('server error', error);
    if (error.error instanceof Error) {
      const erroMessage = error.message;
      return throwError(() => erroMessage);
    }
    return throwError(() => error || 'server error');
  }
}
