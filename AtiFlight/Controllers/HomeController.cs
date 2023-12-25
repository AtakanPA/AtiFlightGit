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
            var now=DateTime.UtcNow;
            var today = DateTime.UtcNow.Date;
            var tomorrow=today.AddDays(1);
            var pastFlight=c.Flights.Include(ap=>ap.AirPlane).ThenInclude(ae=>ae.Seats).Where(f=>f.Start<now&& f.IsActive).ToList();
            foreach(var f in pastFlight)
            {   foreach(var ae in f.AirPlane.Seats)
                {

                    ae.IsFull = false;
                    ae.YolcuId = null;

                }
                var newStartDate = new DateTime(tomorrow.Year, tomorrow.Month, tomorrow.Day, f.Start.Hour, f.Start.Minute, f.Start.Second, DateTimeKind.Utc);
                var newEndDate = new DateTime(tomorrow.Year, tomorrow.Month, tomorrow.Day, f.End.Hour, f.End.Minute, f.End.Second, DateTimeKind.Utc);
                Flight add = new Flight()
                {
                    Start = newStartDate,
                    End = newEndDate,
                    AirPlaneID = f.AirPlaneID,
                    FlyRouteID = f.FlyRouteID,
                    Price = f.Price,


                };
        
                c.Flights.Add(add);
                f.IsActive = false;
            }
            c.SaveChanges();

            var iller = Im.GetAll();
            ViewBag.illerStartList = new SelectList(iller, "IlId", "Name");
            ViewBag.illerEndList = new SelectList(iller, "IlId", "Name");

          
            return View();
        }

        public IActionResult BiletSorgula()
        {



            return View();
        }
        [HttpPost]
        public IActionResult BiletSorgula(string PNR)
        {
            MyContext c= new MyContext();
            var exist = c.Ticket
           .Include(fl => fl.Flight)
               .ThenInclude(fr => fr.FlyRoute)
                   .ThenInclude(s => s.Start)
           .Include(fl => fl.Flight)
               .ThenInclude(fr => fr.FlyRoute)
                   .ThenInclude(s => s.End)
           .Include(ylc => ylc.Yolcu)
           .Include(st => st.Seat)
           .FirstOrDefault(pn => pn.PNR.Equals(PNR));
            if (exist!=null)
            {




                return View(exist);
            }
            else
            {


                ViewBag.Bulunamadi = "Bilet Bulunamadı";
                return View();
            }

           
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
