using Newtonsoft.Json;

namespace Simulation.Domain.Entities
{
    public class SimulationsResponse
    {
        [JsonProperty("wealth")]
        public Wealth Wealth { get; set; }
    }
}