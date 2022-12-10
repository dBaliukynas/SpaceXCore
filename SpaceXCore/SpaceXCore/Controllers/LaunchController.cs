using Microsoft.AspNetCore.Mvc;
using SpaceXAPI;
using SpaceXCore.Models;
using SpaceXCore.Models.ViewModels;

namespace SpaceXCore.Controllers
{
    public class LaunchController : Controller
    {
        [Route("Launch/{id}")]
        public async Task<IActionResult> Index(string id)
        {
            SpaceXAPIClient client = new SpaceXAPIClient(new HttpClient());

            var responseLaunch = await client.GetLaunch(id);
            var launch = new LaunchModel(responseLaunch);

            launch.Rocket = new RocketModel(await client.GetRocket(launch.RocketId));

            var model = new LaunchViewModel();
            model.Launch = launch;

            return View("Launch", model);
        }
    }
}
