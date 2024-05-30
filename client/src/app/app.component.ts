import { AfterViewInit, ChangeDetectorRef, Component, ViewChild } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { AssetClassComponent } from './asset-class/asset-class.component';
import { ApiService } from './core/services/api.service';
import { TotalChartComponent } from "./total-chart/total-chart.component";
import { Asset } from './core/models/asset';
import { ContributionRequest } from './core/models/contributionRequest';
import { ContributionRequestComponent } from "./contribution-request/contribution-request.component";
import { SpinnerComponent } from "./shared/spinner/spinner.component";

@Component({
  selector: 'app-root',
  standalone: true,
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
  imports: [CommonModule, FormsModule, AssetClassComponent, TotalChartComponent, ContributionRequestComponent, SpinnerComponent]
})
export class AppComponent implements AfterViewInit {
  title = 'simulation';

  // Loading
  isLoading: boolean = true;
  isSimulationLoading: boolean = false;

  // Scenario spaces
  options = [
    { value: 'default_2c', display: 'default_2c' },
    { value: 'chf_default_3a', display: 'chf_default_3a' },
    { value: 'us_default_4b', display: 'us_default_4b' },
    { value: 'dvv_3a', display: 'dvv_3a' }
  ];
  selectedOption: string = this.options[0].value;
  assets: Asset[] = [];

  // Contributions
  contributionRequests: ContributionRequest[] = [];
  @ViewChild(TotalChartComponent) private totalChartComponent!: TotalChartComponent;

  constructor(private apiService: ApiService, private cdr: ChangeDetectorRef) { }

  // Init
  ngOnInit(): void {
    this.loadScenarioSpaceSummary();
  }

  ngAfterViewInit(): void {
    this.cdr.detectChanges();
  }

  // Summary
  loadScenarioSpaceSummary(): void {
    this.isLoading = true;
    this.apiService.getSummary(this.selectedOption).subscribe({
      next: (data) => {
        this.assets = data;
        this.contributionRequests = [];
        this.contributionRequests.push(new ContributionRequest());
        this.isLoading = false;
      },
      error: (error) => {
        console.error('Failed to fetch data:', error);
        this.isLoading = false;
      }
    });
  }

  // Simulation
  loadSimulations(): void {
    this.isSimulationLoading = true;
    this.apiService.getSimulations(this.selectedOption, this.assets, this.contributionRequests).subscribe({
      next: (data) => {
        if (data !== null) {
          this.totalChartComponent.updateChartData([
            { name: "percentile 5", data: data["percentile5"] },
            { name: "percentile 50", data: data["percentile50"] },
            { name: "percentile 75", data: data["percentile75"] }
          ]);
          this.isSimulationLoading = false;
          this.totalChartComponent.openModal();
        }
      },
      error: (error) => console.error('Failed to fetch data:', error)
    });
  }
}