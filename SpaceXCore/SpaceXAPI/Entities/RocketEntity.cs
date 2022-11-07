using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SpaceXAPI.Entities
{
    public class RocketEntity
    {
        public string Name { get; set; }
        public Dictionary<string, float> Height { get; set; }

        [JsonPropertyName("flickr_images")]
        public List<string> FlickrImages { get; set; }
    }
}
