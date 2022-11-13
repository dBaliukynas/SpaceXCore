using AutoFixture;
using SpaceXAPI.Entities;
using System.Net;
using System.Text.Json;
using FluentAssertions;
using Moq;
using Moq.Protected;

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


        public Mock<HttpMessageHandler> mockHttpClient(string jsonContent, string requestUri)
        {
            Mock<HttpMessageHandler> handlerMock = new Mock<HttpMessageHandler>();

            handlerMock.Protected().Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.Is<HttpRequestMessage>(message => message.RequestUri == new Uri(requestUri)), ItExpr.IsAny<CancellationToken>())
            .ReturnsAsync(new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(jsonContent)
            });

            return handlerMock;
        }

        [Fact]
        public async void TestF1()
        {
            SpaceXAPIClient client = new SpaceXAPIClient(new HttpClient(mockHttpClient(jsonLaunchEntityList, "https://api.spacexdata.com/v5/launches").Object));

            var launchEntityList = await client.GetLaunches();

            launchEntityList.Should().BeEquivalentTo(launchEntityListFixture);
        }

        [Fact]
        public async void TestF2()
        {
            SpaceXAPIClient client = new SpaceXAPIClient(new HttpClient(mockHttpClient(jsonLaunchEntity, $"https://api.spacexdata.com/v5/launches/{launchEntityFixture.Id}").Object));

            var launchEntity = await client.GetLaunch(launchEntityFixture.Id);

            launchEntity.Should().BeEquivalentTo(launchEntityFixture);
        }

        [Fact]
        public async void TestF3()
        {
            SpaceXAPIClient client = new SpaceXAPIClient(new HttpClient(mockHttpClient(jsonLaunchEntity, "https://api.spacexdata.com/v5/launches/latest").Object));

            var launchEntity = await client.GetLatestLaunch();

            launchEntity.Should().BeEquivalentTo(launchEntityFixture);
        }

        [Fact]
        public async void TestF4()
        {
            SpaceXAPIClient client = new SpaceXAPIClient(new HttpClient(mockHttpClient(jsonRocketEntityList, "https://api.spacexdata.com/v4/rockets").Object));

            var rocketEntityList = await client.GetRockets();

            rocketEntityList.Should().BeEquivalentTo(rocketEntityListFixture);
        }

        [Fact]
        public async void TestF5()
        {
            SpaceXAPIClient client = new SpaceXAPIClient(new HttpClient(mockHttpClient(jsonRocketEntity, $"https://api.spacexdata.com/v4/rockets/{rocketEntityFixture.Id}").Object));

            var rocketEntity = await client.GetRocket(rocketEntityFixture.Id);

            rocketEntity.Should().BeEquivalentTo(rocketEntityFixture);
        }

    }
}