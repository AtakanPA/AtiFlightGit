using AtiFlight.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol;

namespace AtiFlight.ViewComponents.AirPlane
{
    public class AirPlaneList:ViewComponent
    {
        public IViewComponentResult Invoke()
        {

            MyContext c=new MyContext();
            var values = c.AirPlanes
         .Include(ap => ap.Flight)
             .ThenInclude(f => f.FlyRoute)
                 .ThenInclude(fr => fr.Start) // Include Start related to FlyRoute
         .Include(ap => ap.Flight)
             .ThenInclude(f => f.FlyRoute)
                 .ThenInclude(fr => fr.End) // Include End related to FlyRoute
         .ToList();

            return View(values);


        }




    }
}
