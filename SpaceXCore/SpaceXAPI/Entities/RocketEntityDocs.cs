using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SpaceXAPI.Entities
{
    public class RocketEntityDocs
    {
        [JsonPropertyName("docs")]
        public List<RocketEntity> Docs { get; set; }
    }
}
