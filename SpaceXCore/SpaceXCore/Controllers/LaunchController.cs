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

            ViewBag.launch = launch;

            return View("Launch");
        }
    }
}
