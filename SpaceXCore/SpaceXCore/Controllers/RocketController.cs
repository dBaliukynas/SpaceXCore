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
            SpaceXAPIClient client = new SpaceXAPIClient(new HttpClient());

            var responseRocket = await client.GetRocket(id);
            var rocket = new RocketModel(responseRocket);

            ViewBag.rocket = rocket;

            return View("Rocket");
        }
    }
}
