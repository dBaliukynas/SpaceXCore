using Microsoft.AspNetCore.Mvc;
using SpaceXAPI;
using SpaceXCore.Models;
using SpaceXCore.Models.ViewModels;

namespace SpaceXCore.Controllers
{
    public class RocketController : Controller
    {
        private readonly ISpaceXAPIClient _spaceXAPIClient;

        public RocketController(ISpaceXAPIClient spaceXAPIClient)
        {
            _spaceXAPIClient = spaceXAPIClient;
        }

        [Route("Rocket/{id}")]
        public async Task<IActionResult> Index(string id)
        {
            var responseRocket = await _spaceXAPIClient.GetRocket(id);
            var rocket = new RocketModel(responseRocket);

            var model = new RocketViewModel();
            model.Rocket = rocket;

            return View("Rocket", model);
        }
    }
}
