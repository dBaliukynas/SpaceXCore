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
    public class SpaceXAPIClient
    {
        private HttpClient client;
        public SpaceXAPIClient(HttpClient httpClient)
        {
            client = httpClient;
        }

        private JsonSerializerOptions serializerOptions = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
        };

        public async Task<List<LaunchEntity>> GetLaunches()
        {
            string responseBody = await client.GetStringAsync("https://api.spacexdata.com/v5/launches");

            return JsonSerializer.Deserialize<List<LaunchEntity>>(responseBody, serializerOptions);
        }

        public async Task<LaunchEntity> GetLaunch(string id)
        {
            string responseBody = await client.GetStringAsync($"https://api.spacexdata.com/v5/launches/{id}");

            return JsonSerializer.Deserialize<LaunchEntity>(responseBody, serializerOptions);
        }

        public async Task<LaunchEntity> GetLatestLaunch()
        {
            string responseBody = await client.GetStringAsync("https://api.spacexdata.com/v5/launches/latest");

            return JsonSerializer.Deserialize<LaunchEntity>(responseBody, serializerOptions); ;
        }

        public async Task<List<RocketEntity>> GetRockets()
        {
            string responseBody = await client.GetStringAsync("https://api.spacexdata.com/v4/rockets");

            return JsonSerializer.Deserialize<List<RocketEntity>>(responseBody, serializerOptions);
        }

        public async Task<RocketEntity> GetRocket(string id)
        {
            string responseBody = await client.GetStringAsync($"https://api.spacexdata.com/v4/rockets/{id}");

            return JsonSerializer.Deserialize<RocketEntity>(responseBody, serializerOptions);
        }
     
    }
}