using MediatR;
using Newtonsoft.Json;
using Simulation.Application.Dtos;
using Simulation.Domain.Entities;

namespace Simulation.Application.Features.Summary.Queries.GetScenarioSpaceSummaries
{
    public class GetScenarioSpaceSummaryQueriesHandler : IRequestHandler<GetScenarioSpaceSummariesQuery, IReadOnlyList<AssetDto>>
    {
        private readonly HttpClient _httpClient;

        public GetScenarioSpaceSummaryQueriesHandler(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("HttpService"); ;
        }

        public async Task<IReadOnlyList<AssetDto>> Handle(GetScenarioSpaceSummariesQuery request, CancellationToken cancellationToken)
        {
            var url = $"scenarioSpaceSummary?scenarioSpace={request.ScenarioSpace}";
            var response = await _httpClient.GetAsync(url, cancellationToken);

            if (!response.IsSuccessStatusCode)
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                throw new HttpRequestException($"API call failed with status code {response.StatusCode}: {errorContent}");
            }

            var content = await response.Content.ReadAsStringAsync();
            var scenarioSpaceSummaries = JsonConvert.DeserializeObject<ScenarioSpaceSummary>(content);

            if (scenarioSpaceSummaries == null || scenarioSpaceSummaries.AssetClasses.Count == 0)
                return new List<AssetDto>();

            return scenarioSpaceSummaries.AssetClasses.Keys
                .Select(key => new AssetDto(key))
                .ToList()
                .AsReadOnly();
        }
    }
}