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

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }


        public async Task<IActionResult> Index()
        {
            SpaceXAPIClient client = new SpaceXAPIClient(new HttpClient());

            var responseRockets = await client.GetRockets();
            var responseLaunches = await client.GetLaunches();
            var responseLatestLaunch = await client.GetLatestLaunch();

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