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
            Mass = rocketEntity.Mass.Kg.GetValueOrDefault();
            Cost = rocketEntity.CostPerLaunch.GetValueOrDefault();
            ReusableFS = rocketEntity.FirstStage.Reusable.GetValueOrDefault();
            ThrustSeaLevelFS = rocketEntity.FirstStage.ThrustSeaLevel.KN.GetValueOrDefault();
            ThrustVacuumFS = rocketEntity.FirstStage.ThrustVacuum.KN.GetValueOrDefault();
            ReusableSS = rocketEntity.SecondStage.Reusable.GetValueOrDefault();
            ThrustSS = rocketEntity.SecondStage.Thrust.KN.GetValueOrDefault();
            Stages = rocketEntity.Stages.GetValueOrDefault();
            Boosters = rocketEntity.Boosters.GetValueOrDefault();
            FirstFlight = rocketEntity.FirstFlight.GetValueOrDefault().ToString("yyyy-MM-dd");
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
        public long Cost { get; set; }
        public bool ReusableFS { get; set; }
        public long ThrustSeaLevelFS { get; set; }
        public long ThrustVacuumFS { get; set; }
        public bool ReusableSS { get; set; }
        public long ThrustSS { get; set; }
        public int Stages { get; set; }
        public int Boosters { get; set; }
        public string FirstFlight { get; set; }
    }
}
