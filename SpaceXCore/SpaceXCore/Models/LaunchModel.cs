using SpaceXAPI.Entities;

namespace SpaceXCore.Models
{
    public class LaunchModel
    {
        public LaunchModel(LaunchEntity launchEntity)
        {
            Name = launchEntity.Name;
        }
        public string Name { get; set; }
    }
}
