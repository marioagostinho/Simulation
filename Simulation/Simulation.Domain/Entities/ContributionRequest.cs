using Newtonsoft.Json;

namespace Simulation.Domain.Entities
{
    public class ContributionRequest
    {
        [JsonProperty("name")]
        public string? Name { get; set; }
        [JsonProperty("nominal")]
        public bool? Nominal { get; set; }
        [JsonProperty("values")]
        public Dictionary<int, float>? Values { get; set; }
        [JsonProperty("portfolio")]
        public int? Portfolio { get; set; }

        ContributionRequest() { }
    }
}
