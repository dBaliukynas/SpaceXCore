using Microsoft.AspNetCore.Mvc;
using SpaceXAPI;
using SpaceXCore.Models;

namespace SpaceXCore.Controllers
{
    public class RocketController : Controller
    {
        [Route("Rocket/{id}")]
        public async Task<IActionResult> Index(string id)
        {
            var responseRocket = await SpaceXAPIClient.GetRocket(id);
            var rocket = new RocketModel(responseRocket);

            ViewBag.rocket = rocket;

            return View("Rocket");
        }
    }
}
