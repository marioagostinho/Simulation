using Newtonsoft.Json;

namespace Simulation.Domain.Entities
{
    public class Asset
    {
        [JsonProperty("asset_class")]
        public string AssetClass { get; set; }
        [JsonProperty("initial_allocation")]
        public double InitialAllocation { get; set; }
        [JsonProperty("asset_mgmt_fee")]
        public double AssetMgmtFee { get; set; }
        [JsonProperty("initial_load_fee")]
        public double InitialLoadFee { get; set; }

        public Asset() { }
    }
}
