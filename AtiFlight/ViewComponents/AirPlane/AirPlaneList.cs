using AtiFlight.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AtiFlight.ViewComponents.AirPlane
{
    public class AirPlaneList:ViewComponent
    {
        public IViewComponentResult Invoke()
        {

            MyContext c=new MyContext();
            var values=c.AirPlanes.Include(fl=>fl.Flight).ToList();


            return View(values);


        }




    }
}
