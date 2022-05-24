using GameMasster.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace GameMasster.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult menu()
        {
            return View();
        }

        public IActionResult menu2()
        {
            return View();
        }

        public IActionResult menu3()
        {
            return View();
        }

        public IActionResult Revolution()
        {
            return View();
        }

        public IActionResult Rogue()
        {
            return View();
        }

        public IActionResult Unity()
        {
            return View();
        }

        public IActionResult Sekiro()
        {
            return View();
        }

        public IActionResult Vahala()
        {
            return View();
        }

        public IActionResult EldenRing()
        {
            return View();
        }

        public IActionResult TheWitcher3()
        {
            return View();
        }

        public IActionResult ShadowOfWar()
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
