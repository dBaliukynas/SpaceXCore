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
            Height = rocketEntity.Height;
            FlickrImages = rocketEntity.FlickrImages;
        }

        public string Name { get; set; }
        public Dictionary<string, float> Height { get; set; }
        [JsonPropertyName("flickr_images")]
        public List<string> FlickrImages { get; set; }
    }
}
