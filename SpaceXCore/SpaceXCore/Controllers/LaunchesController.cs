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
        public async Task<IActionResult> Index()
        {
            SpaceXAPIClient client = new SpaceXAPIClient(new HttpClient());

           
            var responseLaunches = await client.GetLaunches();
            var launches = responseLaunches.Select(launch => new LaunchModel(launch));

            var model = new LaunchesViewModel();
            model.Launches = launches;

            return View("Launches", model);
        }
    }
}