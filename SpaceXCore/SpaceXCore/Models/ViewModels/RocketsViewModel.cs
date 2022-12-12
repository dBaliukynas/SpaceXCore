namespace SpaceXCore.Models.ViewModels
{
    public class RocketsViewModel
    {
        public IEnumerable<RocketModel> AllRockets { get; set; }
        public IEnumerable<RocketModel> ListedRockets { get; set; }
        public string Name { get; set; }
        public double? Height { get; set; }
        public long? CostPerLaunch { get; set; }
        public bool? ReusableFS { get; set; }
        public bool? NotReusableFS { get; set; }

    }
}
