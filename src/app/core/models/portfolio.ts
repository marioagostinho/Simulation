import { Asset } from "./asset";

export class Portfolio {
    name: string;
    assets: Asset[];
    rebalancing_frequency: number;
    cash_asset_class_name: string;
    portfolio_mgmt_fee: number;
    liquid: boolean;
    capital_gain_tax_rate: number;
    income_tax_rate: number;
    max_credit_fraction?: number;

    constructor(assets: Asset[], scenarioSpace: string) {
        this.name = 'Test';
        this.assets = assets;
        this.rebalancing_frequency = 2;
        this.cash_asset_class_name = this.scenarioToCurrencyMap[scenarioSpace];
        this.portfolio_mgmt_fee = 0;
        this.liquid = true;
        this.capital_gain_tax_rate = 0.15;
        this.income_tax_rate = 0.15;
        this.max_credit_fraction = 0.5;
    }

    private scenarioToCurrencyMap: { [key: string]: string } = {
        'default_2c': 'CS_EUR',
        'dvv_3a': 'CS_EUR',
        'chf_default_3a': 'CS_CHF',
        'us_default_4b': 'CS_USD'
    };
}