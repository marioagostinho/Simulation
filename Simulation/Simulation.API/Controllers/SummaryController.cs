using MediatR;
using Microsoft.AspNetCore.Mvc;
using Simulation.Application.Features.Summary.Queries.GetScenarioSpaceSummaries;

namespace Simulation.API.Controllers
{
    public class SummaryController : BaseAPIController
    {
        private readonly IMediator _mediator;

        public SummaryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetSummariesByScenarioSpace/{scenarioSpace}")]
        public async Task<IActionResult> GetSummaries(string scenarioSpace)
        {
            var result = await _mediator.Send(new GetScenarioSpaceSummariesQuery(scenarioSpace));
            return Ok(result);
        }
    }
}
