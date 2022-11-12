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

    }
}