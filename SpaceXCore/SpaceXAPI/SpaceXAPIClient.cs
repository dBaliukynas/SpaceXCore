using System;
using System.Net.Sockets;
using System.Text.Json;
using SpaceXAPI.Entities;

namespace SpaceXAPI
{
    public class SpaceXAPIClient
    {
        static readonly HttpClient client = new HttpClient();

        static readonly JsonSerializerOptions serializerOptions = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };

        public static async Task<List<LaunchEntity>> GetLaunches()
        {
            string responseBody = await client.GetStringAsync("https://api.spacexdata.com/v5/launches");

            return JsonSerializer.Deserialize<List<LaunchEntity>>(responseBody, serializerOptions);
        }

        public static async Task<LaunchEntity> GetLaunch(string id)
        {
            string responseBody = await client.GetStringAsync($"https://api.spacexdata.com/v5/launches/{id}");
            Console.WriteLine(responseBody);

            return JsonSerializer.Deserialize<LaunchEntity>(responseBody, serializerOptions);
        }

        public static async Task<LaunchEntity> GetLatestLaunch()
        {
            string responseBody = await client.GetStringAsync("https://api.spacexdata.com/v5/launches/latest");

            return JsonSerializer.Deserialize<LaunchEntity>(responseBody, serializerOptions); ;
        }

        public static async Task<List<RocketEntity>> GetRockets()
        {

            string responseBody = await  client.GetStringAsync("https://api.spacexdata.com/v4/rockets");

            return JsonSerializer.Deserialize<List<RocketEntity>>(responseBody, serializerOptions);
        }

        public static async Task<RocketEntity> GetRocket(string id)
        {

            string responseBody = await client.GetStringAsync($"https://api.spacexdata.com/v4/rockets/{id}");

            return JsonSerializer.Deserialize<RocketEntity>(responseBody, serializerOptions);
        }
    }
}