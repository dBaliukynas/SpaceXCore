namespace SpaceXCore.Models.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<RocketModel>Rockets;
        public IEnumerable<LaunchModel> Launches;
        public LaunchModel LatestLaunch;
    }
}
