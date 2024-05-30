using Newtonsoft.Json;

namespace Simulation.Application.Dtos
{
    public class ContributionRequestDto
    {
        [JsonProperty("name")]
        public string? Name { get; set; }
        [JsonProperty("nominal")]
        public bool? Nominal { get; set; }
        [JsonProperty("values")]
        public Dictionary<int, float>? Values { get; set; }
        [JsonProperty("portfolio")]
        public int? Portfolio { get; set; }

        public ContributionRequestDto() { }
    }
}
