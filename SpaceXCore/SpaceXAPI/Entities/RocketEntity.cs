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
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("flickr_images")]
        public List<Uri> Images { get; set; }
        public string Id { get; set; }

        [JsonPropertyName("height")]
        public Diameter Height { get; set; }

        [JsonPropertyName("diameter")]
        public Diameter Diameter { get; set; }

        [JsonPropertyName("mass")]
        public Mass Mass { get; set; }

        [JsonPropertyName("first_stage")]
        public FirstStage FirstStage { get; set; }

        [JsonPropertyName("second_stage")]
        public SecondStage SecondStage { get; set; }

        [JsonPropertyName("engines")]
        public Engine Engines { get; set; }

        [JsonPropertyName("landing_legs")]
        public LandingLegs LandingLegs { get; set; }

        [JsonPropertyName("payload_weights")]
        public PayloadWeight[] PayloadWeights { get; set; }


        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("active")]
        public bool? Active { get; set; }

        [JsonPropertyName("stages")]
        public int? Stages { get; set; }

        [JsonPropertyName("boosters")]
        public int? Boosters { get; set; }

        [JsonPropertyName("cost_per_launch")]
        public long? CostPerLaunch { get; set; }

        [JsonPropertyName("success_rate_pct")]
        public long? SuccessRatePct { get; set; }

        [JsonPropertyName("first_flight")]
        public DateTime? FirstFlight { get; set; }

        [JsonPropertyName("country")]
        public string Country { get; set; }

        [JsonPropertyName("company")]
        public string Company { get; set; }

        [JsonPropertyName("wikipedia")]
        public Uri Wikipedia { get; set; }
    }

    public class Diameter
    {
        [JsonPropertyName("meters")]
        public double? Meters { get; set; }

        [JsonPropertyName("feet")]
        public double? Feet { get; set; }
    }

    public class Engine
    {
        [JsonPropertyName("isp")]
        public Isp Isp { get; set; }

        [JsonPropertyName("thrust_sea_level")]
        public Thrust ThrustSeaLevel { get; set; }

        [JsonPropertyName("thrust_vacuum")]
        public Thrust ThrustVacuum { get; set; }

        [JsonPropertyName("number")]
        public long? Number { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("version")]
        public string Version { get; set; }

        [JsonPropertyName("layout")]
        public string Layout { get; set; }

        [JsonPropertyName("engine_loss_max")]
        public long? EngineLossMax { get; set; }

        [JsonPropertyName("propellant_1")]
        public string Propellant1 { get; set; }

        [JsonPropertyName("propellant_2")]
        public string Propellant2 { get; set; }

        [JsonPropertyName("thrust_to_weight")]
        public double ThrustToWeight { get; set; }
    }

    public class Isp
    {
        [JsonPropertyName("sea_level")]
        public long? SeaLevel { get; set; }

        [JsonPropertyName("vacuum")]
        public long? Vacuum { get; set; }
    }

    public class Thrust
    {
        [JsonPropertyName("kN")]
        public long? KN { get; set; }

        [JsonPropertyName("lbf")]
        public long? Lbf { get; set; }
    }

    public class FirstStage
    {
        [JsonPropertyName("thrust_sea_level")]
        public Thrust ThrustSeaLevel { get; set; }

        [JsonPropertyName("thrust_vacuum")]
        public Thrust ThrustVacuum { get; set; }

        [JsonPropertyName("reusable")]
        public bool? Reusable { get; set; }

        [JsonPropertyName("engines")]
        public long? Engines { get; set; }

        [JsonPropertyName("fuel_amount_tons")]
        public double? FuelAmountTons { get; set; }

        [JsonPropertyName("burn_time_sec")]
        public double? BurnTimeSec { get; set; }
    }

    public class LandingLegs
    {
        [JsonPropertyName("number")]
        public long? Number { get; set; }

        [JsonPropertyName("material")]
        public string Material { get; set; }
    }

    public class Mass
    {
        [JsonPropertyName("kg")]
        public long? Kg { get; set; }

        [JsonPropertyName("lb")]
        public long? Lb { get; set; }
    }

    public class PayloadWeight
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("kg")]
        public long? Kg { get; set; }

        [JsonPropertyName("lb")]
        public long? Lb { get; set; }
    }

    public class SecondStage
    {
        [JsonPropertyName("thrust")]
        public Thrust Thrust { get; set; }

        [JsonPropertyName("payloads")]
        public Payload Payloads { get; set; }

        [JsonPropertyName("reusable")]
        public bool? Reusable { get; set; }

        [JsonPropertyName("engines")]
        public long? Engines { get; set; }

        [JsonPropertyName("fuel_amount_tons")]
        public double FuelAmountTons { get; set; }

        [JsonPropertyName("burn_time_sec")]
        public double? BurnTimeSec { get; set; }
    }

    public class Payload
    {
        [JsonPropertyName("composite_fairing")]
        public CompositeFairing CompositeFairing { get; set; }

        [JsonPropertyName("option_1")]
        public string Option1 { get; set; }
    }

    public class CompositeFairing
    {
        [JsonPropertyName("height")]
        public Diameter Height { get; set; }

        [JsonPropertyName("diameter")]
        public Diameter Diameter { get; set; }
    }
}

