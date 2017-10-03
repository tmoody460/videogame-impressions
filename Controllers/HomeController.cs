using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VideoGameImpressions.DataAccess;
using VideoGameImpressions.Models;
using VideoGameImpressions.Models.Custom;

namespace VideoGameImpressions.Controllers
{
    public class HomeController : Controller
    {
        private readonly IVideoGameAccessor _accessor;

        public HomeController(IVideoGameAccessor accessor)
        {
            _accessor = accessor;
        }

        public IActionResult Index()
        {
            var game = _accessor.AddVideoGame(new VideoGame
            {
                Name = "Stanley Parable"
            });

            ViewData["InsertedID"] = game.Id;

            var retreived = _accessor.GetVideoGame(game.Id);

            ViewData["RetreivedName"] = game.Name;

            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
