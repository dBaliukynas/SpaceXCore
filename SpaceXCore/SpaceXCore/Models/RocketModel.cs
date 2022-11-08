using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using SpaceXAPI.Entities;

namespace SpaceXCore.Models
{
    public class RocketModel
    {
        public RocketModel (RocketEntity rocketEntity)
        {
            Name = rocketEntity.Name;
            Height = rocketEntity.Height.Meters.GetValueOrDefault();
            Diameter = rocketEntity.Diameter.Meters.GetValueOrDefault();
            Mass = rocketEntity.Mass.Kg;
            Cost = rocketEntity.CostPerLaunch;
            Description = rocketEntity.Description;
            Images = rocketEntity.Images;
            Id = rocketEntity.Id;
            
        }

        public string Name { get; set; }
        public double Height { get; set; }

        public string Description { get; set; }

        [JsonPropertyName("flickr_images")]
        public List<Uri> Images { get; set; }

        public string Id { get; set; }
        public double Diameter { get; set; }
        public long Mass { get; set; }
        public long  Cost { get; set; }
    }
}
