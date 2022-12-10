using Microsoft.AspNetCore.Mvc;
using SpaceXAPI;
using SpaceXCore.Models;
using SpaceXCore.Models.ViewModels;

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

            var model = new RocketViewModel();
            model.Rocket = rocket;

            return View("Rocket", model);
        }
    }
}
