using Newtonsoft.Json;

namespace Simulation.Domain.Entities
{
    public class Total
    {
        [JsonProperty("percentile5")]
        public List<double> Percentile5 { get; set; }

        [JsonProperty("percentile50")]
        public List<double> Percentile50 { get; set; }

        [JsonProperty("percentile75")]
        public List<double> Percentile75 { get; set; }
    }
}
