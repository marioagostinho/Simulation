import { Component, Input } from '@angular/core';
import { Asset } from '../core/models/asset';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-asset-class',
  standalone: true,
  imports: [
    CommonModule,
    FormsModule
  ],
  templateUrl: './asset-class.component.html',
  styleUrl: './asset-class.component.css'
})
export class AssetClassComponent {
  @Input() assets: Asset[] = [];
}
