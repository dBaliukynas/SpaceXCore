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

        [JsonPropertyName("fairings")]
        public object Fairings { get; set; }

        [JsonPropertyName("static_fire_date_utc")]
        public DateTimeOffset? StaticFireDateUtc { get; set; }

        [JsonPropertyName("static_fire_date_unix")]
        public long? StaticFireDateUnix { get; set; }

        [JsonPropertyName("tdb")]
        public bool Tdb { get; set; }

        [JsonPropertyName("net")]
        public bool Net { get; set; }

        [JsonPropertyName("window")]
        public int? Window { get; set; }

        [JsonPropertyName("rocket")]
        public string Rocket { get; set; }

        [JsonPropertyName("success")]
        public bool? Success { get; set; }

        [JsonPropertyName("failures")]
        public object[] Failures { get; set; }

        [JsonPropertyName("details")]
        public string Details { get; set; }

        [JsonPropertyName("crew")]
        public object[] Crew { get; set; }

        [JsonPropertyName("ships")]
        public object[] Ships { get; set; }

        [JsonPropertyName("capsules")]
        public string[] Capsules { get; set; }

        [JsonPropertyName("payloads")]
        public string[] Payloads { get; set; }

        [JsonPropertyName("launchpad")]
        public string Launchpad { get; set; }

        [JsonPropertyName("auto_update")]
        public bool AutoUpdate { get; set; }

        [JsonPropertyName("flight_number")]
        public long FlightNumber { get; set; }

        [JsonPropertyName("date_utc")]
        public DateTimeOffset DateUtc { get; set; }

        [JsonPropertyName("date_unix")]
        public long DateUnix { get; set; }

        [JsonPropertyName("date_local")]
        public DateTimeOffset DateLocal { get; set; }

        [JsonPropertyName("date_precision")]
        public string DatePrecision { get; set; }

        [JsonPropertyName("upcoming")]
        public bool Upcoming { get; set; }

        [JsonPropertyName("cores")]
        public CoreEntity[] Cores { get; set; }

        [JsonPropertyName("id")]
        public string Id { get; set; }

    }

    public class CoreEntity
    {
        [JsonPropertyName("core")]
        public string Core { get; set; }

        [JsonPropertyName("flight")]
        public long? Flight { get; set; }

        [JsonPropertyName("gridfins")]
        public bool? Gridfins { get; set; }

        [JsonPropertyName("legs")]
        public bool? Legs { get; set; }

        [JsonPropertyName("reused")]
        public bool? Reused { get; set; }

        [JsonPropertyName("landing_attempt")]
        public bool? LandingAttempt { get; set; }

        [JsonPropertyName("landing_success")]
        public bool? LandingSuccess { get; set; }

        [JsonPropertyName("landing_type")]
        public string LandingType { get; set; }

        [JsonPropertyName("landpad")]
        public string Landpad { get; set; }
    }

    public class MediaLink
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

    public class Flickr
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

    public class Reddit
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

