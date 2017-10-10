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
            var retreived = _accessor.AddVideoGameNote("59dc1fc745ec230b68b0ac20", new Note
            {
                Content = "It's like Skyrim, but more focused. Less bullshit."
            });

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
