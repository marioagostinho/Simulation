import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, catchError } from 'rxjs';
import { Asset } from '../models/asset';
import { ContributionRequest } from '../models/contributionRequest';

@Injectable({
  providedIn: 'root'
})
export class ApiService {
  private baseUrl = 'http://localhost:5000/api/v1/';
  //private baseUrl = 'https://localhost:7126/api/v1/';

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
  getSimulations(scenarioSpace: string, assets: Asset[], contributionRequest: ContributionRequest[]): Observable<any> {
    const headers = new HttpHeaders({
      'Content-Type': 'application/json'
    });

    const body = {
      "scenarioSpace": scenarioSpace,
      "assets": assets,
      "contributionRequest": contributionRequest
    };

    return this.http.post(`${this.baseUrl}Simulation/GetSimulations`, body, { headers: headers })
      .pipe(
        catchError(error => {
          console.error('Error fetching simulations:', error);
          throw error;
        })
      );
  }
}
