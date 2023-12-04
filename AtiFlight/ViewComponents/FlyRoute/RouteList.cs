using AtiFlight.BusinessLayer.Concrete;
using AtiFlight.Context;
using AtiFlight.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AtiFlight.ViewComponents.FlyRoute
{
    public class RouteList:ViewComponent
    {
        FlyRouteManager rm = new FlyRouteManager(new EfFlyRouteRepository());
        public IViewComponentResult Invoke()
        {
            MyContext c = new MyContext();
           
            var values = c.FlyRoutes.Include(fe => fe.Start).Include(fs => fs.End).ToList();



            return View(values);
        }
    }
}
