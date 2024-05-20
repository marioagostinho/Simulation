using Moq;
using Moq.Protected;
using Newtonsoft.Json;
using Shouldly;
using Simulation.Application.Features.Summary.Queries.GetScenarioSpaceSummaries;
using Simulation.Domain.Entities;
using System.Net;

namespace Simulation.Application.UnitTest.Features.Summary.Queries
{
    public class GetScenarioSpaceSummaryQueriesHandlerTests
    {
        private readonly Mock<IHttpClientFactory> _httpClientFactoryMock;
        private readonly Mock<HttpMessageHandler> _httpMessageHandlerMock;
        private readonly GetScenarioSpaceSummaryQueriesHandler _handler;

        public GetScenarioSpaceSummaryQueriesHandlerTests()
        {
            _httpClientFactoryMock = new Mock<IHttpClientFactory>();
            _httpMessageHandlerMock = new Mock<HttpMessageHandler>();

            var httpClient = new HttpClient(_httpMessageHandlerMock.Object)
            {
                BaseAddress = new System.Uri("https://stage.3rd-eyes.com/api/public/v1/")
            };

            httpClient.DefaultRequestHeaders.Add("X-API-Key", "A6CAFBD3-448F-4599-BD23-7C96B61E194F");

            _httpClientFactoryMock.Setup(x => x.CreateClient(It.IsAny<string>())).Returns(httpClient);

            _handler = new GetScenarioSpaceSummaryQueriesHandler(_httpClientFactoryMock.Object);
        }

        [Fact]
        public async Task Handle_ReturnsAssetDtos_WhenApiCallIsSuccessful()
        {
            // Arrange
            var scenarioSpace = "default_2c";

            var scenarioSpaceSummary = new ScenarioSpaceSummary
            {
                AssetClasses = new Dictionary<string, AssetClass>
                {
                    { "EQ_W", new AssetClass { Returns = new ReturnData { Kurtosis = 0.9802367, Mean = 0.069576986, Skewness = 0.0, StandardDeviation = 0.18200128 }, Wealth = null } },
                    { "GOV_EM", new AssetClass { Returns = new ReturnData { Kurtosis = 3.263181, Mean = 0.055858675, Skewness = 0.0, StandardDeviation = 0.13093726 }, Wealth = null } },
                    { "EQ_W_HED", new AssetClass { Returns = new ReturnData { Kurtosis = 1.0644065, Mean = 0.06325867, Skewness = 0.0, StandardDeviation = 0.16000342 }, Wealth = null } },
                    { "INFLATION", new AssetClass { Returns = new ReturnData { Kurtosis = -0.1705541, Mean = 0.018077943, Skewness = 0.0, StandardDeviation = 0.005807212 }, Wealth = null } },
                    { "EQ_EM", new AssetClass { Returns = new ReturnData { Kurtosis = 0.28926194, Mean = 0.11058546, Skewness = 0.0, StandardDeviation = 0.29002133 }, Wealth = null } },
                    { "EQ_DE", new AssetClass { Returns = new ReturnData { Kurtosis = 1.554227, Mean = 0.08728781, Skewness = 0.0, StandardDeviation = 0.2382018 }, Wealth = null } },
                    { "EQ_EU", new AssetClass { Returns = new ReturnData { Kurtosis = 1.0028064, Mean = 0.07161492, Skewness = 0.0, StandardDeviation = 0.1848845 }, Wealth = null } },
                    { "RE_DE_DIR", new AssetClass { Returns = new ReturnData { Kurtosis = -0.1705541, Mean = 0.018077943, Skewness = 0.0, StandardDeviation = 0.005807212 }, Wealth = null } },
                    { "GOV_EU", new AssetClass { Returns = new ReturnData { Kurtosis = 0.60520065, Mean = 0.026345218, Skewness = 0.0, StandardDeviation = 0.0375171 }, Wealth = null } },
                    { "BD_W", new AssetClass { Returns = new ReturnData { Kurtosis = 0.7211887, Mean = 0.037206385, Skewness = 0.0, StandardDeviation = 0.076259054 }, Wealth = null } },
                    { "BD_W_HY", new AssetClass { Returns = new ReturnData { Kurtosis = 2.3151238, Mean = 0.057036445, Skewness = 0.0, StandardDeviation = 0.110429 }, Wealth = null } },
                    { "AI_EU_PE", new AssetClass { Returns = new ReturnData { Kurtosis = 1.0028064, Mean = 0.07161492, Skewness = 0.0, StandardDeviation = 0.1848845 }, Wealth = null } },
                    { "CORP_EU", new AssetClass { Returns = new ReturnData { Kurtosis = 1.4157463, Mean = 0.03036848, Skewness = 0.0, StandardDeviation = 0.03667862 }, Wealth = null } },
                    { "INTEREST", new AssetClass { Returns = new ReturnData { Kurtosis = -0.106307365, Mean = 0.15014096, Skewness = 0.0, StandardDeviation = 0.023476044 }, Wealth = null } },
                    { "AI_NC_ALL", new AssetClass { Returns = new ReturnData { Kurtosis = 4.276989, Mean = 0.022587467, Skewness = 0.0, StandardDeviation = 0.07496842 }, Wealth = null } },
                    { "CS_EUR", new AssetClass { Returns = new ReturnData { Kurtosis = 0.2439087, Mean = 0.010085253, Skewness = 0.0, StandardDeviation = 0.0069442717 }, Wealth = null } },
                    { "AI_NC_GOLD", new AssetClass { Returns = new ReturnData { Kurtosis = 0.9667564, Mean = 0.02904002, Skewness = 0.0, StandardDeviation = 0.14048089 }, Wealth = null } }
                },
                Inflation = new ReturnData
                {
                    Kurtosis = -0.1705541,
                    Mean = 0.018077943,
                    Skewness = 0.0,
                    StandardDeviation = 0.005807212
                }
            };

            var responseContent = new StringContent(JsonConvert.SerializeObject(scenarioSpaceSummary));
            var responseMessage = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = responseContent
            };

            _httpMessageHandlerMock
                .Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(responseMessage);

            var request = new GetScenarioSpaceSummariesQuery(scenarioSpace);

            // Act
            var result = await _handler.Handle(request, CancellationToken.None);

            // Assert
            result.ShouldNotBeNull();
            result.Count.ShouldBe(17);
        }
    }
}
