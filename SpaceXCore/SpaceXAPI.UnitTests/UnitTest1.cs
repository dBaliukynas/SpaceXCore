using AutoFixture;
using SpaceXAPI.Entities;
using System.Net;
using System.Text.Json;
using FluentAssertions;
using Moq;
using Moq.Protected;
using System.Threading;

namespace SpaceXAPI.UnitTests
{
    public class SpaceXAPIClientTests
    {
        Fixture fixture = new Fixture();

        static LaunchEntity launchEntityFixture = new Fixture().Create<LaunchEntity>();
        static string jsonLaunchEntity = JsonSerializer.Serialize(launchEntityFixture);

        static RocketEntity rocketEntityFixture = new Fixture().Create<RocketEntity>();
        static string jsonRocketEntity = JsonSerializer.Serialize(rocketEntityFixture);

        static List<RocketEntity> rocketEntityListFixture = new Fixture().CreateMany<RocketEntity>(50).ToList();
        static string jsonRocketEntityList = JsonSerializer.Serialize(rocketEntityListFixture);

        static List<LaunchEntity> launchEntityListFixture = new Fixture().CreateMany<LaunchEntity>(50).ToList();
        static string jsonLaunchEntityList = JsonSerializer.Serialize(launchEntityListFixture);


        public Mock<HttpMessageHandler> MockHttpClient(string jsonContent, string requestUri)
        {
            Mock<HttpMessageHandler> handlerMock = new Mock<HttpMessageHandler>();

            handlerMock.Protected().Setup<Task<HttpResponseMessage>>("SendAsync",
                                                                     ItExpr.Is<HttpRequestMessage>(message => message.RequestUri == new Uri(requestUri)),
                                                                     ItExpr.IsAny<CancellationToken>())
            .ReturnsAsync(new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(jsonContent)
            });

            return handlerMock;
        }

        public void verifySendAsyncCalledOnce(Mock<HttpMessageHandler> handlerMock, string requestUri)
        {
            handlerMock.Protected().Verify("SendAsync", Times.Once(),
            ItExpr.Is<HttpRequestMessage>(message => message.RequestUri == new Uri(requestUri)),
            ItExpr.IsAny<CancellationToken>());
        }
    

        [Fact]
        public async void TestGetLaunches()
        {
            var requestUri = "https://api.spacexdata.com/v5/launches";
            var handlerMock = MockHttpClient(jsonLaunchEntityList, requestUri);

            ISpaceXAPIClient client = new SpaceXAPIClient(new HttpClient(handlerMock.Object));

            var launchEntityList = await client.GetLaunches();

            launchEntityList.Should().BeEquivalentTo(launchEntityListFixture);

            verifySendAsyncCalledOnce(handlerMock, requestUri);

        }

        [Fact]
        public async void TestGetLaunch()
        {
            var requestUri = $"https://api.spacexdata.com/v5/launches/{launchEntityFixture.Id}";
            var handlerMock = MockHttpClient(jsonLaunchEntity, requestUri);
            ISpaceXAPIClient client = new SpaceXAPIClient(new HttpClient(handlerMock.Object));

            var launchEntity = await client.GetLaunch(launchEntityFixture.Id);

            launchEntity.Should().BeEquivalentTo(launchEntityFixture);

            verifySendAsyncCalledOnce(handlerMock, requestUri);
        }

        [Fact]
        public async void TestGetLatestLaunch()
        {
            var requestUri = "https://api.spacexdata.com/v5/launches/latest";
            var handlerMock = MockHttpClient(jsonLaunchEntity, requestUri);
            ISpaceXAPIClient client = new SpaceXAPIClient(new HttpClient(handlerMock.Object));

            var launchEntity = await client.GetLatestLaunch();

            launchEntity.Should().BeEquivalentTo(launchEntityFixture);

            verifySendAsyncCalledOnce(handlerMock, requestUri);
        }

        [Fact]
        public async void TestGetRockets()
        {
            var requestUri = "https://api.spacexdata.com/v4/rockets";
            var handlerMock = MockHttpClient(jsonRocketEntityList, requestUri);
            ISpaceXAPIClient client = new SpaceXAPIClient(new HttpClient(handlerMock.Object));

            var rocketEntityList = await client.GetRockets();

            rocketEntityList.Should().BeEquivalentTo(rocketEntityListFixture);

            verifySendAsyncCalledOnce(handlerMock, requestUri);
        }

        [Fact]
        public async void TestGetRocket()
        {
            var requestUri = $"https://api.spacexdata.com/v4/rockets/{rocketEntityFixture.Id}";
            var handlerMock = MockHttpClient(jsonRocketEntity, requestUri);
            ISpaceXAPIClient client = new SpaceXAPIClient(new HttpClient(handlerMock.Object));

            var rocketEntity = await client.GetRocket(rocketEntityFixture.Id);

            rocketEntity.Should().BeEquivalentTo(rocketEntityFixture);

            verifySendAsyncCalledOnce(handlerMock, requestUri);
        }

    }
}