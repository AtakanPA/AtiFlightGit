using AtiFlight.BusinessLayer.Concrete;
using AtiFlight.Context;
using AtiFlight.EntityFramework;
using AtiFlight.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace AtiFlight.Controllers
{
  
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        IllerManager Im = new IllerManager(new EfIllerRepository());
        FlyRouteManager Frm = new FlyRouteManager(new EfFlyRouteRepository());
        MyContext c = new MyContext();
        public IActionResult Index()
        {

            return View();






        }
        public IActionResult AddRoute()
        {
            var iller = Im.GetAll();
            ViewBag.illerStartList = new SelectList(iller, "IlId", "Name");
            ViewBag.illerEndList = new SelectList(iller, "IlId", "Name");
            if (TempData.ContainsKey("SameValues"))
            {


                ViewBag.SameValue = TempData["SameValues"];

            }
            else
            {

                ViewBag.SameValue = null;

            }
            if (TempData.ContainsKey("RouteExist"))
            {


                ViewBag.Failed = TempData["RouteExist"];

            }
            else
            {

                ViewBag.Failed = null;

            }
            if (TempData.ContainsKey("RouteSuccess"))
            {


                ViewBag.Success = TempData["RouteSuccess"];


            }
            else
            {

                ViewBag.Success = null;



            }

            return View();
        }
        [HttpPost]
        public IActionResult AddRoute(FlyRoute flr)
        {

            var iller = Im.GetAll();
            ViewBag.illerStartList = new SelectList(iller, "IlId", "Name");
            ViewBag.illerEndList = new SelectList(iller, "IlId", "Name");
            bool exists = c.FlyRoutes.Any(route =>
         route.StartID == flr.StartID && route.EndID == flr.EndID);
            if (flr.StartID == flr.EndID)
            {


                TempData["SameValues"] = "Aynı şehirleri seçtiniz";

                return RedirectToAction("AddRoute");

            }
            if (exists)
            {


                TempData["RouteExist"] = "Rota zaten var !";
                return RedirectToAction("AddRoute");

            }
            else
            {

                Frm.TAdd(flr);
                TempData["RouteSuccess"] = "Rota başarıyla oluşturuldu";

                return RedirectToAction("AddingRouteSuccess");

            }






        }

        public IActionResult AddingRouteSuccess()
        {




            return RedirectToAction("AddRoute");
        }

        public IActionResult AddPlane()
        {

            return View();

        }
        [HttpPost]
        public IActionResult AddPlane(AirPlane airplane)
        {

            if (ModelState.IsValid)
            {
                int addedAirPlaneID = airplane.AirPlaneID;
                c.AirPlanes.Add(airplane);
                c.SaveChanges();
                for (int i = 0; i < 40; i++)
                {

                    Seat newSeat = new Seat { AirPlaneID = airplane.AirPlaneID, IsFull = false, SeatNumber = i };
                   var a= newSeat.SeatID;
                    
                    c.Seats.Add(newSeat);

                }
                c.SaveChanges();

                return RedirectToAction("AddingPlaneSucces");
            }
            else
            {
                return RedirectToAction("AddPlane");
            }

        }

        public IActionResult AddingPlaneSucces()
        {


            return RedirectToAction("AddPlane");


        }
        public IActionResult DeleteRoute()
        {


            return View();
        }

        public IActionResult AddFlight(int id)
        {


            ViewBag.FlyRouteID = id;
            var airplaneIds = c.AirPlanes.Where(airplane=>airplane.isAvailable==true).Select(airplane => new SelectListItem
            {
                Value = airplane.AirPlaneID.ToString(), // Assuming Id is int, convert it to string
                Text = airplane.AirPlaneID.ToString()   // Assign appropriate text if necessary
            }).ToList();
            ViewBag.AirPlanes = new SelectList(airplaneIds, "Value", "Text");
            return View();

        }
        [HttpPost]
        public IActionResult AddFlight(Flight flight)
        {
            if (ModelState.IsValid)
            {
                TimeZoneInfo tzi = TimeZoneInfo.FindSystemTimeZoneById("Turkey Standard Time");

                flight.Start = DateTime.SpecifyKind(flight.Start, DateTimeKind.Utc);
                flight.End = DateTime.SpecifyKind(flight.End, DateTimeKind.Utc);
                var AirPlaneUpdate = c.AirPlanes.FirstOrDefault(c => c.AirPlaneID == flight.AirPlaneID);
                if (AirPlaneUpdate != null)
                {
                    AirPlaneUpdate.FlightID = flight.FlightID;
                    AirPlaneUpdate.isAvailable = false;

                }
                c.Flights.Add(flight);
                c.SaveChanges();
                return RedirectToAction("AddRoute");
            }
            else
            {



                return RedirectToAction("AddFlight");

            }

        }

    }
}
