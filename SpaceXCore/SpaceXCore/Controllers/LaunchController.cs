using Microsoft.AspNetCore.Mvc;
using SpaceXAPI;
using SpaceXCore.Models;
using SpaceXCore.Models.ViewModels;

namespace SpaceXCore.Controllers
{
    public class LaunchController : Controller
    {
        private readonly ISpaceXAPIClient _spaceXAPIClient;

        public LaunchController(ISpaceXAPIClient spaceXAPIClient)
        {
            _spaceXAPIClient = spaceXAPIClient;
        }

        [Route("Launch/{id}")]
        public async Task<IActionResult> Index(string id)
        {

            var responseLaunch = await _spaceXAPIClient.GetLaunch(id);
            var launch = new LaunchModel(responseLaunch);

            launch.Rocket = new RocketModel(await _spaceXAPIClient.GetRocket(launch.RocketId));

            var model = new LaunchViewModel();
            model.Launch = launch;

            return View("Launch", model);
        }
    }
}
