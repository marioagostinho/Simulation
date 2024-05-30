using MediatR;
using Simulation.Application.Dtos;
using System.Text.Json.Serialization;

namespace Simulation.Application.Features.Simulation.Queries.GetSimulationsQuery
{
    public class GetSimulationsQuery : IRequest<SimulationPercentileDto>
    {
        [JsonPropertyName("scenarioSpace")]
        public string ScenarioSpace { get; set; }

        [JsonPropertyName("assets")]
        public List<AssetDto> Assets { get; set; }

        [JsonPropertyName("contributionRequest")]
        public List<ContributionRequestDto> ContributionRequest { get; set; }

        public GetSimulationsQuery() { }
    }
}
