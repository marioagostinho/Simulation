using MediatR;
using Simulation.Application.Dtos;
using System.Text.Json.Serialization;

namespace Simulation.Application.Features.Simulation.Queries.GetSimulationsQuery
{
    public class GetSimulationsQuery : IRequest<double[][]>
    {
        [JsonPropertyName("assets")]
        public List<AssetDto> Assets { get; set; }

        [JsonPropertyName("scenarioSpace")]
        public string ScenarioSpace { get; set; }

        public GetSimulationsQuery() { }
    }
}
