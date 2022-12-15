using Microsoft.AspNetCore.Mvc;
using SpaceXAPI;
using SpaceXCore.Models;
using SpaceXCore.Models.ViewModels;
using System.Diagnostics;

namespace SpaceXCore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ISpaceXAPIClient _spaceXAPIClient;

        public HomeController(ILogger<HomeController> logger, ISpaceXAPIClient spaceXAPIClient)
        {
            _logger = logger;
            _spaceXAPIClient = spaceXAPIClient;
        }


        public async Task<IActionResult> Index()
        {
            var responseRockets = await _spaceXAPIClient.GetRockets();
            var responseLaunches = await _spaceXAPIClient.GetLaunches();
            var responseLatestLaunch = await _spaceXAPIClient.GetLatestLaunch();

            var rockets = responseRockets.Select(rocket => new RocketModel(rocket));
            var launches = responseLaunches.Select(launch => new LaunchModel(launch));
            var latestLaunch = new LaunchModel(responseLatestLaunch);

            var model = new HomeViewModel();

            model.Rockets = rockets;
            model.Launches = launches;
            model.LatestLaunch = latestLaunch;

            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}