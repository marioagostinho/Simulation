import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, catchError } from 'rxjs';
import { Asset } from '../models/asset';

@Injectable({
  providedIn: 'root'
})
export class ApiService {
  private baseUrl = 'http://localhost:5000/api/v1/';

  constructor(private http: HttpClient) { }

  // Contact with summary endpoint
  getSummary(scenarioSpace: string): Observable<any> {
    const headers = new HttpHeaders({
      'Content-Type': 'application/json'
    });

    return this.http.get(`${this.baseUrl}Summary/GetSummariesByScenarioSpace/${scenarioSpace}`, { headers: headers })
      .pipe(
        catchError(error => {
          console.error('Error fetching scenario space summary:', error);
          throw error;
        })
      );
  }

  // Contact with simulations endpoint
  getSimulations(assets: Asset[], scenarioSpace: string): Observable<any> {
    const headers = new HttpHeaders({
      'Content-Type': 'application/json'
    });

    const body = {
      "assets": assets,
      "scenarioSpace": scenarioSpace
    };

    console.log(body);

    return this.http.post(`${this.baseUrl}Simulation/GetSimulations`, body, { headers: headers })
      .pipe(
        catchError(error => {
          console.error('Error fetching simulations:', error);
          throw error;
        })
      );
  }
}
