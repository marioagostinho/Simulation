import { Component, Input } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ContributionRequest } from '../core/models/contributionRequest';
import { KeyValuePairsPipe } from '../pipes/key-value-pairs.pipe';

@Component({
  selector: 'app-contribution-request',
  standalone: true,
  imports: [CommonModule, FormsModule, KeyValuePairsPipe],
  templateUrl: './contribution-request.component.html',
  styleUrl: './contribution-request.component.css'
})
export class ContributionRequestComponent {
  @Input() contributionRequests: ContributionRequest[] = [];

  // Contributions
  addContributionRequest(): void {
    this.contributionRequests.push(new ContributionRequest());
  }

  removeContributionRequest(index: number): void {
    this.contributionRequests.splice(index, 1);
  }

  // Values
  addValue(request: ContributionRequest): void {
    const newKey = this.getNextKey(request.values);
    request.values = {
      ...request.values,
      [newKey]: 0
    };
  }

  private getNextKey(values: { [key: number]: number }): number {
    const keys = Object.keys(values).map(key => Number(key));
    return keys.length ? Math.max(...keys) + 1 : 1;
  }

  // Validation
  validatePortfolio(request: ContributionRequest): void {
    request.portfolio = Math.floor(request.portfolio);
  }
}
