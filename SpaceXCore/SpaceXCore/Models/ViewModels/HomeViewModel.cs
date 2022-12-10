namespace SpaceXCore.Models.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<RocketModel>Rockets { get; set; }
        public IEnumerable<LaunchModel> Launches { get; set; }
        public LaunchModel LatestLaunch { get; set; }
    }
}
