using MediatR;
using Microsoft.AspNetCore.Mvc;
using Simulation.Application.Features.Simulation.Queries.GetSimulationsQuery;

namespace Simulation.API.Controllers
{
    public class SimulationController : BaseAPIController
    {
        private readonly IMediator _mediator;

        public SimulationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("GetSimulations")]
        public async Task<IActionResult> GetSimulations(GetSimulationsQuery simulations)
        {
            var result = await _mediator.Send(simulations);
            return Ok(result);
        }
    }
}
