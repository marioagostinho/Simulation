export class Asset {
    asset_class: string;
    initial_allocation: number;
    asset_mgmt_fee: number;
    initial_load_fee: number;

    constructor(assetClass: string) {
        this.asset_class = assetClass;
        this.initial_allocation = 1000;
        this.asset_mgmt_fee = 0.0015;
        this.initial_load_fee = 0;
    }
}