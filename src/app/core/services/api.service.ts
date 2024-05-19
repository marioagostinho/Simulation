import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, catchError } from 'rxjs';
import { SimulationsRequest } from '../models/simulatonsRequest';

@Injectable({
  providedIn: 'root'
})
export class ApiService {
  private apiUrl = 'https://stage.3rd-eyes.com/api/public/v1';
  private apiKey = 'A6CAFBD3-448F-4599-BD23-7C96B61E194F';

  constructor(private http: HttpClient) { }

  // Contact with summary endpoint
  getSummary(scenarioSpace: string): Observable<any> {
    const headers = new HttpHeaders({
      'Content-Type': 'application/json',
      'X-API-Key': `${this.apiKey}`
    });

    const params = new HttpParams().set('scenarioSpace', scenarioSpace);

    return this.http.get(`${this.apiUrl}/scenarioSpaceSummary`, { headers: headers, params: params })
      .pipe(
        catchError(error => {
          console.error('Error fetching scenario space summary:', error);
          throw error;
        })
      );
  }

  // Contact with simulations endpoint
  getSimulations(simulations: SimulationsRequest, scenarioSpace: string): Observable<any> {
    const headers = new HttpHeaders({
      'Content-Type': 'application/json',
      'X-API-Key': `${this.apiKey}`
    });

    const params = new HttpParams().set('scenarioSpace', scenarioSpace);

    const body = {
      ...simulations
    };

    return this.http.post(`${this.apiUrl}/simulations`, body, { headers: headers, params: params })
      .pipe(
        catchError(error => {
          console.error('Error fetching simulations:', error);
          throw error;
        })
      );
  }
}
