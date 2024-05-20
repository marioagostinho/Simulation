using Newtonsoft.Json;

namespace Simulation.Domain.Entities
{
    public class ScenarioSpaceSummary
    {
        [JsonProperty("asset_classes")]
        public Dictionary<string, AssetClass> AssetClasses { get; set; }
        [JsonProperty("inflation")]
        public ReturnData Inflation { get; set; }
    }
}
