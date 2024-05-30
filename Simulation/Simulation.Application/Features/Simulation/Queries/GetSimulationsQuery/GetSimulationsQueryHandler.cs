using AutoMapper;
using MediatR;
using Newtonsoft.Json;
using Simulation.Application.Dtos;
using Entities = Simulation.Domain.Entities;

namespace Simulation.Application.Features.Simulation.Queries.GetSimulationsQuery
{
    public class GetSimulationsQueryHandler : IRequestHandler<GetSimulationsQuery, SimulationPercentileDto>
    {
        private readonly HttpClient _httpClient;
        private readonly IMapper _mapper;

        public GetSimulationsQueryHandler(IHttpClientFactory httpClientFactory, IMapper mapper)
        {
            _httpClient = httpClientFactory.CreateClient("HttpService");
            _mapper = mapper;
        }

        public async Task<SimulationPercentileDto> Handle(GetSimulationsQuery request, CancellationToken cancellationToken)
        {
            var url = $"simulations?scenarioSpace={request.ScenarioSpace}";

            var assets = _mapper.Map<List<Entities.Asset>>(request.Assets);
            var contributionRequest = _mapper.Map<List<Entities.ContributionRequest>>(request.ContributionRequest);

            var portfolio = new Entities.Portfolio(assets, request.ScenarioSpace);
            var simulation = new Entities.Simulation(new List<Entities.Portfolio>() { portfolio }, contributionRequest);

            var jsonContent = JsonConvert.SerializeObject(simulation);
            var httpContent = new StringContent(jsonContent, System.Text.Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(url, httpContent, cancellationToken);

            if (!response.IsSuccessStatusCode)
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                throw new HttpRequestException($"API call failed with status code {response.StatusCode}: {errorContent}");
            }

            var content = await response.Content.ReadAsStringAsync();
            var simulations = JsonConvert.DeserializeObject<Entities.SimulationsResponse>(content);

            if (simulations == null || simulations.Wealth == null || simulations.Wealth.Total == null)
                return new SimulationPercentileDto();

            return new SimulationPercentileDto(
                simulations.Wealth.Total.Percentile5.ToArray(),
                simulations.Wealth.Total.Percentile50.ToArray(),
                simulations.Wealth.Total.Percentile75.ToArray()
            );
        }
    }
}
