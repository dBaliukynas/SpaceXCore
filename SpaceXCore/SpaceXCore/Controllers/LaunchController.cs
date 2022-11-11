using Microsoft.AspNetCore.Mvc;
using SpaceXAPI;
using SpaceXCore.Models;

namespace SpaceXCore.Controllers
{
    public class LaunchController : Controller
    {
        [Route("Launch/{id}")]
        public async Task<IActionResult> Index(string id)
        {
            var responseLaunch = await SpaceXAPIClient.GetLaunch(id);
            var launch = new LaunchModel(responseLaunch);

            launch.Rocket = new RocketModel(await SpaceXAPIClient.GetRocket(launch.RocketId));

            ViewBag.launch = launch;

            return View("Launch");
        }
    }
}
