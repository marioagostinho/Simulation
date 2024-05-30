export class ContributionRequest {
    name: string;
    nominal: boolean;
    values: { [key: number]: number };
    portfolio: number;

    constructor(key: number = 1) {
        this.name = '';
        this.nominal = false;
        this.values = { [key]: 0 };
        this.portfolio = 0;
    }
}