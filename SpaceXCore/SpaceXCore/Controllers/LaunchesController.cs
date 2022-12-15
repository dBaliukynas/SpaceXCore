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
        public async Task<IActionResult> Index([FromQuery] string name, [FromQuery(Name = "rocket-name")] string rocketName,
            [FromQuery()] bool? succeeded, [FromQuery(Name = "not-succeeded")] bool? notSucceeded)
        {
            SpaceXAPIClient client = new SpaceXAPIClient(new HttpClient());

           
            var responseLaunches = await client.GetLaunches();
            var responseRockets = await client.GetRockets();

            var allLaunches = responseLaunches.Select(launch => new LaunchModel(launch));
            var rockets = responseRockets.Select(rocket => new RocketModel(rocket)).ToList();

            Dictionary<string, string> rocketIdToNameMapping = rockets.ToDictionary(rocket => rocket.Id, rocket => rocket.Name);


        var listedLaunches = allLaunches
                .Where(launch => name == null || launch.Name == name)
                .Where(launch => rocketName == null || rocketName == rocketIdToNameMapping[launch.RocketId])
                .Where(launch => succeeded == launch.Success && launch.Success != null || notSucceeded == !launch.Success && launch.Success != null ||
                                 succeeded == null && notSucceeded == null).ToList();

            var model = new LaunchesViewModel();

            model.AllLaunches = allLaunches;
            model.ListedLaunches = listedLaunches;
            model.Rockets = rockets;
            model.Name = name;
            model.RocketName = rocketName;
            model.Succeeded = succeeded;
            model.NotSucceeded = notSucceeded;

            return View("Launches", model);
        }
    }
}