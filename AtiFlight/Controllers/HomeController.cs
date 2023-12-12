using AtiFlight.BusinessLayer.Concrete;
using AtiFlight.Context;
using AtiFlight.EntityFramework;
using AtiFlight.Models;
using MessagePack.Internal;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;


namespace AtiFlight.Controllers
{
    
    [AllowAnonymous]
    public class HomeController : Controller
    {
        IllerManager Im = new IllerManager(new EfIllerRepository());
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
       
        public IActionResult Index()
        {
            MyContext c = new MyContext();

            var iller = Im.GetAll();
            ViewBag.illerStartList = new SelectList(iller, "IlId", "Name");
            ViewBag.illerEndList = new SelectList(iller, "IlId", "Name");

          
            return View();
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
