using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SpaceXAPI.Entities
{
    public class EntityQuery<TEntity>
    {
        [JsonPropertyName("query")]
        public TEntity Query { get; set; }

        [JsonPropertyName("options")]
        public Dictionary<string, object> Options { get; set; }
    }

 
}
