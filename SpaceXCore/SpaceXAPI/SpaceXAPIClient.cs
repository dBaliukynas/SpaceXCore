using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using SpaceXAPI.Entities;

namespace SpaceXAPI
{
    public interface ISpaceXAPIClient
    {
        HttpClient Client { get; }

        Task<List<LaunchEntity>> GetLaunches();
        Task<LaunchEntity> GetLaunch(string id);
        Task<LaunchEntity> GetLatestLaunch();
        Task<List<RocketEntity>> GetRockets();
        Task<RocketEntity> GetRocket(string id);
    }
    public class SpaceXAPIClient : ISpaceXAPIClient
    {
        public HttpClient Client { get; }
        public SpaceXAPIClient(HttpClient httpClient)
        {
            Client = httpClient;
        }

        private JsonSerializerOptions serializerOptions = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
        };

        public async Task<List<LaunchEntity>> GetLaunches()
        {
            string responseBody = await Client.GetStringAsync("https://api.spacexdata.com/v5/launches");

            return JsonSerializer.Deserialize<List<LaunchEntity>>(responseBody, serializerOptions);
        }

        public async Task<LaunchEntity> GetLaunch(string id)
        {
            string responseBody = await Client.GetStringAsync($"https://api.spacexdata.com/v5/launches/{id}");

            return JsonSerializer.Deserialize<LaunchEntity>(responseBody, serializerOptions);
        }

        public async Task<LaunchEntity> GetLatestLaunch()
        {
            string responseBody = await Client.GetStringAsync("https://api.spacexdata.com/v5/launches/latest");

            return JsonSerializer.Deserialize<LaunchEntity>(responseBody, serializerOptions); ;
        }

        public async Task<List<RocketEntity>> GetRockets()
        {
            string responseBody = await Client.GetStringAsync("https://api.spacexdata.com/v4/rockets");

            return JsonSerializer.Deserialize<List<RocketEntity>>(responseBody, serializerOptions);
        }

        public async Task<RocketEntity> GetRocket(string id)
        {
            string responseBody = await Client.GetStringAsync($"https://api.spacexdata.com/v4/rockets/{id}");

            return JsonSerializer.Deserialize<RocketEntity>(responseBody, serializerOptions);
        }
     
    }
}