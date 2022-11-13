using AutoFixture;
using SpaceXAPI.Entities;
using System.Net;
using System.Text.Json;
using FluentAssertions;

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


        public class Test : HttpMessageHandler
        {

            override protected Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
            {
                return Task.FromResult(new HttpResponseMessage() { StatusCode = HttpStatusCode.OK, Content = new StringContent(jsonLaunchEntity) });
            }
        }

        public class Test2 : HttpMessageHandler
        {

            override protected Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
            {
                return Task.FromResult(new HttpResponseMessage() { StatusCode = HttpStatusCode.OK, Content = new StringContent(jsonRocketEntity) });
            }
        }
        public class Test3 : HttpMessageHandler
        {

            override protected Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
            {
                return Task.FromResult(new HttpResponseMessage() { StatusCode = HttpStatusCode.OK, Content = new StringContent(jsonRocketEntityList) });
            }
        }
        public class Test4 : HttpMessageHandler
        {

            override protected Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
            {
                return Task.FromResult(new HttpResponseMessage() { StatusCode = HttpStatusCode.OK, Content = new StringContent(jsonLaunchEntityList) });
            }
        }

        [Fact]
        public async void TestF()
        {
            SpaceXAPIClient client = new SpaceXAPIClient(new HttpClient(new Test()));

            var launchEntity = await client.GetLaunch(launchEntityFixture.Id);

            launchEntity.Should().BeEquivalentTo(launchEntityFixture);
        }
        [Fact]
        public async void TestF2()
        {
            SpaceXAPIClient client = new SpaceXAPIClient(new HttpClient(new Test2()));

            var rocketEntity = await client.GetRocket(rocketEntityFixture.Id);

            rocketEntity.Should().BeEquivalentTo(rocketEntityFixture);
        }
        [Fact]
        public async void TestF3()
        {
            SpaceXAPIClient client = new SpaceXAPIClient(new HttpClient(new Test3()));

            var rocketEntityList = await client.GetRockets();

            rocketEntityList.Should().BeEquivalentTo(rocketEntityListFixture);
        }

        [Fact]
        public async void TestF4()
        {
            SpaceXAPIClient client = new SpaceXAPIClient(new HttpClient(new Test4()));

            var launchEntityList = await client.GetLaunches();

            launchEntityList.Should().BeEquivalentTo(launchEntityListFixture);
        }
    }
}