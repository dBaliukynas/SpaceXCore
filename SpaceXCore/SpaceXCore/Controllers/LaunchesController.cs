using Microsoft.AspNetCore.Mvc;
using SpaceXAPI;
using SpaceXCore.Models;
using SpaceXCore.Models.ViewModels;
using System.Diagnostics;

namespace SpaceXCore.Controllers
{
    public class LaunchesController : Controller
    {
        [Route("Launches")]
        public async Task<IActionResult> Index([FromQuery] string name, [FromQuery(Name = "rocket-name")] string rocketName)
        {
            SpaceXAPIClient client = new SpaceXAPIClient(new HttpClient());

           
            var responseLaunches = await client.GetLaunches();
            var responseRockets = await client.GetRockets();

            var allLaunches = responseLaunches.Select(launch => new LaunchModel(launch));
            var rockets = responseRockets.Select(rocket => new RocketModel(rocket)).ToList();

            Dictionary<string, string> rocketIdToNameMapping = rockets.ToDictionary(rocket => rocket.Id, rocket => rocket.Name);


            var listedLaunches = allLaunches.Where(
                launch => (name == null || launch.Name == name) &&
                (rocketName == null || rocketName == rocketIdToNameMapping[launch.RocketId])).ToList();

            var model = new LaunchesViewModel();

            model.AllLaunches = allLaunches;
            model.ListedLaunches = listedLaunches;
            model.Rockets = rockets;

            return View("Launches", model);
        }
    }
}