using Microsoft.AspNetCore.Mvc;
using SpaceXAPI;
using SpaceXCore.Models;
using SpaceXAPI.Entities;
using System.Diagnostics;

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

            var rockets = responseRockets.Select(rocket => new RocketModel(rocket));

            var rocketEntity = new RocketEntity();
            rocketEntity.Name = name;
            //rocketEntity.FirstStage = new FirstStage();
            //rocketEntity.FirstStage.Reusable = reusable;
            rocketEntity.Height = new Diameter();
            rocketEntity.Height.Meters = height;
            rocketEntity.CostPerLaunch = costPerLaunch;

            var responseQueryRockets = await client.GetRocketsWithQuery(rocketEntity);
            var queryRockets = responseQueryRockets.Select(responseQueryRocket => new RocketModel(responseQueryRocket));
    
            ViewBag.rockets = rockets;

            return View("Rockets");
        }
    }
}