using Newtonsoft.Json;

namespace Simulation.Domain.Entities
{
    public class Simulation
    {
        [JsonProperty("portfolios")]
        public List<Portfolio> Portfolios { get; set; }
        [JsonProperty("goal_percentiles")]
        public List<int> GoalPercentiles { get; set; }
        [JsonProperty("wealth_returns")]
        public List<int> WealthReturns { get; set; }
        [JsonProperty("loan")]
        public List<int> Loan { get; set; }
        [JsonProperty("request_id")]
        public string RequestId { get; set; }
        [JsonProperty("scenarios")]
        public int Scenarios { get; set; }
        [JsonProperty("total_quarters")]
        public int TotalQuarters { get; set; }
        [JsonProperty("active_quarters")]
        public int ActiveQuarters { get; set; }
        [JsonProperty("goals")]
        public List<int> Goals { get; set; }
        [JsonProperty("contributions")]
        public List<int> Contributions { get; set; }
        [JsonProperty("percentiles")]
        public List<int> Percentiles { get; set; }

        public Simulation()
        {
            
        }

        public Simulation(List<Portfolio> portfolios)
        {
            Portfolios = portfolios;
            GoalPercentiles = new List<int> { 5, 10 };
            WealthReturns = new List<int> { 50 };
            Loan = new List<int>();
            RequestId = "3dc32c35-53bf-4a33-aa7f-78b50f609809";
            Scenarios = 1000;
            TotalQuarters = 156;
            ActiveQuarters = 185;
            Goals = new List<int>();
            Contributions = new List<int>();
            Percentiles = new List<int> { 5, 50, 75 };
        }
    }
}
