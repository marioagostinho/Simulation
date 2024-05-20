using Newtonsoft.Json;

namespace Simulation.Domain.Entities
{
    public class AssetClass
    {
        [JsonProperty("returns")]
        public ReturnData Returns { get; set; }
        [JsonProperty("wealth")]
        public object Wealth { get; set; }
    }
}
