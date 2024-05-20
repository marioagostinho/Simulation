using Newtonsoft.Json;

namespace Simulation.Domain.Entities
{
    public class ReturnData
    {
        [JsonProperty("kurtosis")]
        public double Kurtosis { get; set; }
        [JsonProperty("mean")]
        public double Mean { get; set; }
        [JsonProperty("skewnes")]
        public double Skewness { get; set; }
        [JsonProperty("standard_deviation")]
        public double StandardDeviation { get; set; }
    }
}
