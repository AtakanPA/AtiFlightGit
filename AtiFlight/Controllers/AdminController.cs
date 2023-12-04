using AtiFlight.BusinessLayer.Concrete;
using AtiFlight.EntityFramework;
using AtiFlight.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AtiFlight.Controllers
{
    [AllowAnonymous]
    public class AdminController : Controller
    {
      IllerManager Im=new IllerManager(new EfIllerRepository());
      FlyRouteManager Frm=new FlyRouteManager(new EfFlyRouteRepository());
        
        public IActionResult Index()
        {
             
            return View();






        }
        public IActionResult AddRoute()
        {
            var iller=Im.GetAll();
          ViewBag.illerStartList = new SelectList(iller, "IlId", "Name");
          ViewBag.illerEndList = new SelectList(iller, "IlId", "Name");

            return View();
        }
        [HttpPost]  
        public IActionResult AddRoute(FlyRoute flr)
        {

            Frm.TAdd(flr);
            

            var iller = Im.GetAll();
            ViewBag.illerStartList = new SelectList(iller, "IlId", "Name");
            ViewBag.illerEndList = new SelectList(iller, "IlId", "Name");


            return RedirectToAction("AddingRouteSucces");
        }
        
        public IActionResult AddingRouteSucces()
        {




            return RedirectToAction("AddRoute");
        }

        public IActionResult AddPlane()
        {

            return View();

        }

        public IActionResult DeleteRoute() { 
        
        
        return View();
        }

        public IActionResult AddFlight() {



            return View();

        }

       
    }
}
