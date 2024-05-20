using System.Text.Json.Serialization;

namespace Simulation.Application.Dtos
{
    public class AssetDto
    {
        [JsonPropertyName("asset_class")]
        public string AssetClass { get; set; }
        [JsonPropertyName("initial_allocation")]
        public double InitialAllocation { get; set; }
        [JsonPropertyName("asset_mgmt_fee")]
        public double AssetMgmtFee { get; set; }
        [JsonPropertyName("initial_load_fee")]
        public double InitialLoadFee { get; set; }

        public AssetDto() { }

        public AssetDto(string assetName)
        {
            AssetClass = assetName;
            InitialAllocation = 1000;
            AssetMgmtFee = 0.0015;
            InitialLoadFee = 0;
        }
    }
}
