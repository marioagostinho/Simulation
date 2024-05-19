import { Portfolio } from "./portfolio";

export class SimulationsRequest {
    portfolios: Portfolio[];
    goal_percentiles: number[];
    wealth_returns: number[];
    loan: number[];
    request_id: string;
    scenarios: number;
    total_quarters: number;
    active_quarters: number;
    goals: number[];
    contributions: number[];
    percentiles: number[];

    constructor(portfolios: Portfolio[]) {
        this.portfolios = portfolios;
        this.goal_percentiles = [5, 10];
        this.wealth_returns = [50];
        this.loan = [];
        this.request_id = "3dc32c35-53bf-4a33-aa7f-78b50f609809";
        this.scenarios = 1000;
        this.total_quarters = 156;
        this.active_quarters = 185;
        this.goals = [];
        this.contributions = [];
        this.percentiles = [5, 50, 75];
    }
}