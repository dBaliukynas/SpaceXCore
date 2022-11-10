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
            Image = launchEntity.MediaLink.Patch.Large;
        }
        public string Name { get; set; }
        public Uri Image { get; set; }
        public string Details { get; set; }
        public string Id { get; set; }

    }
}
