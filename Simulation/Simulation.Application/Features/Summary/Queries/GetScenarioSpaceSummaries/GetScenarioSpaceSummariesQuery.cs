using MediatR;
using Simulation.Application.Dtos;

namespace Simulation.Application.Features.Summary.Queries.GetScenarioSpaceSummaries
{
    public record GetScenarioSpaceSummariesQuery(string ScenarioSpace) : IRequest<IReadOnlyList<AssetDto>>;
}
