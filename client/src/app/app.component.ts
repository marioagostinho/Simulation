import { AfterViewInit, ChangeDetectorRef, Component, ElementRef, ViewChild } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { AssetClassComponent } from './asset-class/asset-class.component';
import { ApiService } from './core/services/api.service';
import { TotalChartComponent } from "./total-chart/total-chart.component";
import { Modal } from 'bootstrap';
import { Asset } from './core/models/asset';

@Component({
  selector: 'app-root',
  standalone: true,
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
  imports: [CommonModule, FormsModule, AssetClassComponent, TotalChartComponent]
})
export class AppComponent implements AfterViewInit {
  title = 'simulation';
  isLoading: boolean = true;
  isSimulationLoading: boolean = false;

  // Total chart
  @ViewChild('chartModal') private chartModal!: ElementRef;
  @ViewChild(TotalChartComponent) private totalChartComponent!: TotalChartComponent;
  modalInstance!: Modal;

  // Scenario spaces
  options = [
    { value: 'default_2c', display: 'default_2c' },
    { value: 'chf_default_3a', display: 'chf_default_3a' },
    { value: 'us_default_4b', display: 'us_default_4b' },
    { value: 'dvv_3a', display: 'dvv_3a' }
  ];
  selectedOption: string = this.options[0].value;
  assets: Asset[] = [];

  constructor(private apiService: ApiService, private cdr: ChangeDetectorRef) { }

  ngOnInit(): void {
    this.loadScenarioSpaceSummary();
  }

  ngAfterViewInit(): void {
    this.modalInstance = new Modal(this.chartModal.nativeElement, { keyboard: false });
    this.cdr.detectChanges();
  }

  loadScenarioSpaceSummary(): void {
    this.isLoading = true;
    this.apiService.getSummary(this.selectedOption).subscribe({
      next: (data) => {
        console.log(data);
        this.assets = data;
        this.isLoading = false;
      },
      error: (error) => {
        console.error('Failed to fetch data:', error);
        this.isLoading = false;
      }
    });
  }

  loadSimulations(): void {
    this.isSimulationLoading = true;

    this.apiService.getSimulations(this.assets, this.selectedOption).subscribe({
      next: (data) => {
        if (data.length > 0) {
          this.totalChartComponent.updateChartData([
            { name: "percentile 5", data: data[0] },
            { name: "percentile 50", data: data[1] },
            { name: "percentile 75", data: data[2] }
          ]);

          this.isSimulationLoading = false;
          this.openModal();
        }
      },
      error: (error) => console.error('Failed to fetch data:', error)
    });
  }

  // Modal
  openModal(): void {
    this.modalInstance.show();
    this.cdr.detectChanges();
  }

  closeModal(): void {
    this.modalInstance.hide();
  }
}