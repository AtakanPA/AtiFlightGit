using AtiFlight.Models;
using Microsoft.AspNetCore.Mvc;
using AtiFlight.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims; 
namespace AtiFlight.Controllers
{       
    public class UserController : Controller
    {
        
        public IActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
      
        public IActionResult BuyTicket(FlyRoute flr)
        {
           
            List<Flight> flightList = new List<Flight>();
            using (MyContext c = new MyContext())
            {
                var exist = c.FlyRoutes.Include(x=>x.End).Include(y=>y.Start).FirstOrDefault(route => route.StartID == flr.StartID && route.EndID == flr.EndID);
                if (exist != null)
                {
                    
                    
                    

                        flightList = c.Flights.Include(fr => fr.AirPlane).Include(fl => fl.FlyRoute).Where(flist => flist.FlyRouteID == exist.FlyRouteID).ToList();
                    ViewBag.FlightList = flightList;
                    return View(exist);
                }
                else
                {

                    ViewBag.FlightNonExist = "Bu rotaya ait bir uçuş yok ";




                }
             
           
            }
            
           return RedirectToAction("Index","Home");
        }

        [Authorize(Roles = "Member")]
        [HttpGet]
        public IActionResult CreateTicket(int FlightID)
        {

            MyContext c=new MyContext();

            var exist=c.Flights.Include(ap=>ap.AirPlane).Include(fl=>fl.FlyRoute).FirstOrDefault(fr=>fr.FlightID == FlightID);
            if (exist != null)
            {

                var SeatList = c.Seats
     .Where(st => st.AirPlaneID == exist.AirPlaneID)
     .OrderBy(st => st.SeatNumber) // seatNumber'a göre düşükten yükseğe sıralama
     .ToList();
                ViewBag.Seats = SeatList;
                ViewBag.Flight = exist;

                return View();

            }
            else
            {



                return RedirectToAction("Index", "Home");


            }

        }
        [HttpPost]
        [Authorize(Roles = "Member")]
        public IActionResult CreateTicket(Ticket ticket,int selectedSeat)
        {
          
            if (ModelState.IsValid)
            {
                MyContext c = new MyContext();
                string pnr;
                Ticket ifExist = null;
                do
                {
                    

                    pnr = GeneratePNRNumber();
                  ifExist = c.Ticket.FirstOrDefault(tc => tc.PNR == pnr);


                } while (ifExist!=null);
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
           
                Ticket UserTicket = new Ticket()
                {
                    FlightID = ticket.FlightID,
                    SeatID = selectedSeat,
                    UserId =Convert.ToInt32(userId),
                    PNR = pnr,


                };
                c.Ticket.Add(UserTicket);
                Seat seat = c.Seats.FirstOrDefault(st => st.SeatID == UserTicket.SeatID);
                seat.IsFull = true;
                 seat.UserId =Convert.ToInt32(userId);

                c.SaveChanges();

                var CreatedTicket = c.Ticket.FirstOrDefault(pn => pn.PNR == UserTicket.PNR);


                return RedirectToAction("Details", new { id = CreatedTicket.TicketID });



            }
            else
            {




                return RedirectToAction("Index", "Home");


            }
         
        }



        public IActionResult Details(int id)
        {
            MyContext c= new MyContext();

            var ticket = c.Ticket.Include(usr => usr.User).Include(flg => flg.Flight).ThenInclude(arp => arp.FlyRoute).Include(st => st.Seat).FirstOrDefault(tid=>tid.TicketID==id);



            return View(ticket);

        }





        public string GeneratePNRNumber()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789"; // Kullanılacak karakterler
            Random random = new Random();
            string pnr = new string(Enumerable.Repeat(chars, 6) // 6 karakter uzunluğunda PNR oluştur
                .Select(s => s[random.Next(s.Length)]).ToArray());

            return pnr;
        }





    }
}
