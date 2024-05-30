using Newtonsoft.Json;

namespace Simulation.Application.Dtos
{
    public class SimulationPercentileDto
    {
        [JsonProperty("percentile5")]
        public double[]? Percentile5 { get; set; }
        [JsonProperty("percentile50")]
        public double[]? Percentile50 { get; set; }
        [JsonProperty("percentile75")]
        public double[]? Percentile75 { get; set; }

        public SimulationPercentileDto() { }

        public SimulationPercentileDto(double[]? percentile5, double[]? percentile50, double[]? percentile75)
        {
            Percentile5 = percentile5;
            Percentile50 = percentile50;
            Percentile75 = percentile75;
        }
    }
}
