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

        public static async Task Test()
        {
            using HttpResponseMessage response = await client.GetAsync("https://api.spacexdata.com/v5/launches/latest");
            response.EnsureSuccessStatusCode();

            string responseBody = await response.Content.ReadAsStringAsync();

            using HttpResponseMessage response2 = await client.GetAsync("https://api.spacexdata.com/v5/launches");
            response2.EnsureSuccessStatusCode();

            string responseBody2 = await response2.Content.ReadAsStringAsync();

            // Above three lines can be replaced with new helper method below
            // string responseBody = await client.GetStringAsync(uri);



        }

        public static async Task<List<RocketEntity>> GetRockets()
        {

            using HttpResponseMessage response = await client.GetAsync("https://api.spacexdata.com/v4/rockets");
            response.EnsureSuccessStatusCode();

            string responseBody = await response.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<List<RocketEntity>>(responseBody, serializerOptions);
        }
    }
}