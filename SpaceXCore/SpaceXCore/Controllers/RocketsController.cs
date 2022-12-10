using Microsoft.AspNetCore.Mvc;
using SpaceXAPI;
using SpaceXCore.Models;
using SpaceXCore.Models.ViewModels;
using SpaceXAPI.Entities;
using System.Diagnostics;
using System.Net.Sockets;

namespace SpaceXCore.Controllers
{
    public class RocketsController : Controller
    {
        [Route("Rockets")]
        public async Task<IActionResult> Index([FromQuery] bool? reusable,
                                             [FromQuery] string name, [FromQuery] double? height,
                                             [FromQuery] long? costPerLaunch)
        {
            SpaceXAPIClient client = new SpaceXAPIClient(new HttpClient());

            var responseRockets = await client.GetRockets();

            var allRockets = responseRockets.Select(rocket => new RocketModel(rocket));


            var listedRockets = allRockets.Where(
                rocket => (name == null || rocket.Name == name) &&
                (costPerLaunch == null || rocket.Cost == costPerLaunch) &&
                (height == null || rocket.Height == height)).ToList();

            var model = new RocketsViewModel();

            model.AllRockets = allRockets;
            model.ListedRockets = listedRockets;



            return View("Rockets", model);
        }
    }
}