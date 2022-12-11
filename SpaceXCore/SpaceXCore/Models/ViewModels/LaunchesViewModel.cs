namespace SpaceXCore.Models.ViewModels
{
    public class LaunchesViewModel
    {
        public IEnumerable<LaunchModel> AllLaunches { get; set; }
        public IEnumerable<LaunchModel> ListedLaunches { get; set; }
        public IEnumerable<RocketModel> Rockets { get; set; }
    }
}
