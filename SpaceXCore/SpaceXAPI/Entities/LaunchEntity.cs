using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SpaceXAPI.Entities
{
    public class LaunchEntity
    {
        public string Name { get; set; }

        [JsonPropertyName("links")]
        public MediaLink MediaLink { get; set; }
    }

    public partial class MediaLink
    {
        [JsonPropertyName("patch")]
        public Patch Patch { get; set; }

        [JsonPropertyName("reddit")]
        public Reddit Reddit { get; set; }

        [JsonPropertyName("flickr")]
        public Flickr Flickr { get; set; }

        [JsonPropertyName("presskit")]
        public Uri Presskit { get; set; }

        [JsonPropertyName("webcast")]
        public Uri Webcast { get; set; }

        [JsonPropertyName("youtube_id")]
        public string YoutubeId { get; set; }

        [JsonPropertyName("article")]
        public Uri Article { get; set; }

        [JsonPropertyName("wikipedia")]
        public Uri Wikipedia { get; set; }
    }

    public partial class Flickr
    {
        [JsonPropertyName("small")]
        public object[] Small { get; set; }

        [JsonPropertyName("original")]
        public Uri[] Original { get; set; }
    }

    public partial class Patch
    {
        [JsonPropertyName("small")]
        public Uri Small { get; set; }

        [JsonPropertyName("large")]
        public Uri Large { get; set; }
    }

    public partial class Reddit
    {
        [JsonPropertyName("campaign")]
        public Uri Campaign { get; set; }

        [JsonPropertyName("launch")]
        public Uri Launch { get; set; }

        [JsonPropertyName("media")]
        public Uri Media { get; set; }

        [JsonPropertyName("recovery")]
        public object Recovery { get; set; }
    }

}

