using SpaceXAPI.Entities;
using System.Text.Json.Serialization;

namespace SpaceXCore.Models
{
    public class LaunchModel
    {
        public LaunchModel(LaunchEntity launchEntity)
        {
            Name = launchEntity.Name;
            Details = launchEntity.Details;
            Id = launchEntity.Id;
            RocketId = launchEntity.Rocket;
            StaticFireDate = launchEntity.StaticFireDateUtc?.ToString("yyyy-MM-dd");
            LaunchDate = launchEntity.DateLocal.ToString("yyyy-MM-dd");
            Success = launchEntity.Success;
            Image = launchEntity.MediaLink.Patch.Large;
        }
        public string Name { get; set; }
        public Uri Image { get; set; }
        public string Details { get; set; }
        public string Id { get; set; }
        public string RocketId { get; set; }
        public RocketModel Rocket { get; set; }
        public bool? Success { get; set; }
        public string StaticFireDate { get; set; }
        public string LaunchDate { get; set; }

    }
}
