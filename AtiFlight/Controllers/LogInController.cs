using AtiFlight.BusinessLayer.Concrete;
using AtiFlight.EntityFramework;
using AtiFlight.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace AtiFlight.Controllers
{
    public class LogInController : Controller
    {
        UsersManager um = new UsersManager(new EfUserRepository());
        [AllowAnonymous]
        public IActionResult Index()
        {
            ViewBag.RegisterSucceed = TempData["RegisterSucceed"];
            if (TempData.ContainsKey("LoginFailed"))
            {
                ViewBag.LoginFailed = TempData["LoginFailed"];
            }
            else
            {
                ViewBag.LoginFailed = null;
            }
            return View();
        }


        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Index(User usr)
        {
            var User = um.GetAll().FirstOrDefault(x => x.Email == usr.Email && x.Password == usr.Password);
            bool loginSuccess = false;
            if (User != null)
            {

                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, usr.Email),

                    new Claim("CustomClaim", "LoggedIn")

                };
                var customClaim = claims.FirstOrDefault(c => c.Type == "CustomClaim")?.Value;

                ViewBag.Layout = "LoggedIn";
               
                var useridentity=new ClaimsIdentity(claims,"a");
                ClaimsPrincipal user = new ClaimsPrincipal(useridentity);
                await HttpContext.SignInAsync(user);
                loginSuccess = true;
                return RedirectToAction("Index", "Home");

            }



            if (!loginSuccess)
            {
                TempData["LoginFailed"] = "Yanlış E-mail veya şifre";
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index", "Home"); 


        }



    }
}

