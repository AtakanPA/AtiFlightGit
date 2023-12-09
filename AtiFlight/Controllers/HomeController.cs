using AtiFlight.Context;
using AtiFlight.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;


namespace AtiFlight.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        [AllowAnonymous]
        public IActionResult Index()
        {
            MyContext c=new MyContext();

            var nereye = c.FlyRoutes.Include(fr => fr.End).ToList();
            var nereden=c.FlyRoutes.Include(ft => ft.Start).ToList();
            SelectList nereyeSelectList = new SelectList(nereye, "FlyRouteID", "End.Name");
            SelectList neredenSelectList = new SelectList(nereden, "FlyRouteID", "Start.Name");

            ViewBag.NereyeSelectList = nereyeSelectList;
            ViewBag.NeredenSelectList = neredenSelectList;

            return View();
        }
        [HttpPost]
       public IActionResult Index(FlyRoute flr)
        {






            return RedirectToAction("Index");
        }
        
        public IActionResult Privacy()
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