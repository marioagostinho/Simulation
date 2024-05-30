import { AfterViewInit, ChangeDetectorRef, Component, ElementRef, ViewChild } from '@angular/core';
import { NgApexchartsModule, ApexAxisChartSeries, ApexChart, ApexXAxis, ApexDataLabels, ApexTooltip } from 'ng-apexcharts';
import { Modal } from 'bootstrap';

interface ChartOptions {
  series: ApexAxisChartSeries;
  chart: ApexChart;
  xaxis: ApexXAxis;
  dataLabels: ApexDataLabels;
  tooltip: ApexTooltip;
};

@Component({
  selector: 'app-total-chart',
  standalone: true,
  imports: [NgApexchartsModule],
  templateUrl: './total-chart.component.html',
  styleUrls: ['./total-chart.component.css']
})
export class TotalChartComponent implements AfterViewInit {
  @ViewChild('chartModal') private chartModal!: ElementRef;
  modalInstance!: Modal;

  public chartOptions: ChartOptions;

  constructor(private cdr: ChangeDetectorRef) {
    this.chartOptions = {
      series: [
        { name: "A", data: [10, 41, 35, 51, 49, 62, 69, 91, 148] },
        { name: "B", data: [15, 39, 32, 51, 29, 12, 102, 93, 158] }
      ],
      chart: { height: 600, type: "line", zoom: { enabled: false }, toolbar: { show: false } },
      xaxis: { categories: ["Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep"] },
      tooltip: { enabled: true },
      dataLabels: { enabled: false }
    };
  }

  // Init
  ngAfterViewInit(): void {
    this.modalInstance = new Modal(this.chartModal.nativeElement, { keyboard: false });
    this.cdr.detectChanges();
  }

  // Chart
  updateChartData(series: any[]) {
    this.chartOptions = {
      series: series,
      chart: { height: 600, type: "line", zoom: { enabled: false }, toolbar: { show: false } },
      xaxis: { categories: this.generateCategories(series[0].data.length), labels: { show: false } },
      tooltip: { enabled: true },
      dataLabels: { enabled: false }
    };
  }

  private generateCategories(length: number): string[] {
    return Array.from({ length }, (_, i) => `Q${i + 1}`);
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