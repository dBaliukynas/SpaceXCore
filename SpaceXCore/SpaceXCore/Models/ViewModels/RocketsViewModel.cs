namespace SpaceXCore.Models.ViewModels
{
    public class RocketsViewModel
    {
        public IEnumerable<RocketModel> AllRockets { get; set; }
        public IEnumerable<RocketModel> ListedRockets { get; set; }
    }
}
