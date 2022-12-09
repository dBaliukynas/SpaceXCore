using Microsoft.AspNetCore.Mvc;
using SpaceXAPI;
using SpaceXCore.Models;
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
            var responseLatestLaunch = await client.GetLatestLaunch();
            var responseLaunches = await client.GetLaunches();

            var rockets = responseRockets.Select(rocket => new RocketModel(rocket));
            var latestLaunch = new LaunchModel(responseLatestLaunch);
            var launches = responseLaunches.Select(launch => new LaunchModel(launch));

            ViewBag.rockets = rockets;
            ViewBag.latestLaunch = latestLaunch;
            ViewBag.launches = launches;

            return View();
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