using AtiFlight.Models;
using Microsoft.AspNetCore.Mvc;

using AtiFlight.BusinessLayer.Concrete;
using AtiFlight.EntityFramework;
namespace AtiFlight.Controllers
{
    public class UserController : Controller
    {
        
        public IActionResult Index()
        {
            return View();
        }
    
      

  
    }
}
