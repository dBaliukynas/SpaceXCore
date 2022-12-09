using Microsoft.AspNetCore.Mvc;
using SpaceXAPI;
using SpaceXCore.Models;
using System.Diagnostics;

namespace SpaceXCore.Controllers
{
    public class RocketsController : Controller
    {
        [Route("Rockets")]
        public async Task<IActionResult> Index()
        {
            SpaceXAPIClient client = new SpaceXAPIClient(new HttpClient());

            var responseRockets = await client.GetRockets();

            var rockets = responseRockets.Select(rocket => new RocketModel(rocket));

            ViewBag.rockets = rockets;

            return View("Rockets");
        }
    }
}