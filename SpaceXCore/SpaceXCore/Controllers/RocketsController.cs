﻿using Microsoft.AspNetCore.Mvc;
using SpaceXAPI;
using SpaceXCore.Models;
using SpaceXCore.Models.ViewModels;
using SpaceXAPI.Entities;
using System.Diagnostics;
using System.Net.Sockets;
using System.Reflection;

namespace SpaceXCore.Controllers
{
    public class RocketsController : Controller
    {
        private readonly ISpaceXAPIClient _spaceXAPIClient;

        public RocketsController(ISpaceXAPIClient spaceXAPIClient)
        {
            _spaceXAPIClient = spaceXAPIClient;
        }

        [Route("Rockets")]
        public async Task<IActionResult> Index([FromQuery] string name, [FromQuery] double? height,
            [FromQuery(Name = "cost-per-launch")] long? costPerLaunch, [FromQuery(Name = "reusable-fs")] bool? reusableFS,
            [FromQuery(Name = "not-reusable-fs")] bool? notReusableFS)
        {

            var responseRockets = await _spaceXAPIClient.GetRockets();

            var allRockets = responseRockets.Select(rocket => new RocketModel(rocket)).ToList();


            var listedRockets = allRockets
                .Where(rocket => name == null || rocket.Name == name)
                .Where(rocket => costPerLaunch == null || rocket.Cost == costPerLaunch)
                .Where(rocket => height == null || rocket.Height == height)
                .Where(rocket => reusableFS == rocket.ReusableFS ||!notReusableFS == rocket.ReusableFS ||
                reusableFS == null && notReusableFS == null).ToList();

            var model = new RocketsViewModel();

            model.AllRockets = allRockets;
            model.ListedRockets = listedRockets;
            model.Name = name;
            model.Height = height;
            model.CostPerLaunch = costPerLaunch;
            model.ReusableFS = reusableFS;
            model.NotReusableFS = notReusableFS;

            return View("Rockets", model);
        }
    }
}