using Newtonsoft.Json;

namespace Simulation.Domain.Entities
{
    public class Portfolio
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("assets")]
        public List<Asset> Assets { get; set; }
        [JsonProperty("rebalancing_frequency")]
        public int RebalancingFrequency { get; set; }
        [JsonProperty("cash_asset_class_name")]
        public string CashAssetClassName { get; set; }
        [JsonProperty("portfolio_mgmt_fee")]
        public double PortfolioMgmtFee { get; set; }
        [JsonProperty("liquid")]
        public bool Liquid { get; set; }
        [JsonProperty("capital_gain_tax_rate")]
        public double CapitalGainTaxRate { get; set; }
        [JsonProperty("income_tax_rate")]
        public double IncomeTaxRate { get; set; }
        [JsonProperty("max_credit_fraction")]
        public double? MaxCreditFraction { get; set; }

        public Portfolio() { }

        public Portfolio(List<Asset> assets, string scenarioSpace)
        {
            Name = "Test";
            Assets = assets;
            RebalancingFrequency = 2;
            CashAssetClassName = ScenarioToCurrencyMap[scenarioSpace];
            PortfolioMgmtFee = 0;
            Liquid = true;
            CapitalGainTaxRate = 0.15;
            IncomeTaxRate = 0.15;
            MaxCreditFraction = 0.5;
        }

        private static readonly Dictionary<string, string> ScenarioToCurrencyMap = new Dictionary<string, string>
        {
            { "default_2c", "CS_EUR" },
            { "dvv_3a", "CS_EUR" },
            { "chf_default_3a", "CS_CHF" },
            { "us_default_4b", "CS_USD" }
        };
    }
}
