using Newtonsoft.Json;

namespace Simulation.Domain.Entities
{
    public class Wealth
    {
        [JsonProperty("total")]
        public Total Total { get; set; }
    }
}
