using AtiFlight.BusinessLayer.Concrete;
using AtiFlight.EntityFramework;
using AtiFlight.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace AtiFlight.Controllers
{
    public class LogInController : Controller
    {
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;
        public LogInController(SignInManager<User> signInManager, UserManager<User> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [AllowAnonymous]
        public IActionResult Index()
        {
          
            if (User.Identity.IsAuthenticated)
            {
                // Kullanıcı zaten giriş yapmışsa, istenilen sayfaya yönlendir.
                return RedirectToAction("Index", "Home");
            }
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
        public async Task<IActionResult> Index(UserSignInViewModel usr)
        {
         
            if (User.Identity.IsAuthenticated)
            {
                // Kullanıcı zaten giriş yapmışsa, istenilen sayfaya yönlendir.
                return RedirectToAction("Index", "Home");
            }
            var result = await _signInManager.PasswordSignInAsync(usr.Email, usr.Password, false, false);
            if (result.Succeeded)
            {

                var user = await _userManager.FindByEmailAsync(usr.Email);
                if (user != null)

                {

                   
                
                    var roles = await _userManager.GetRolesAsync(user);
                    if (roles.Contains("Admin"))
                    {
                        return RedirectToAction("AddRoute", "Admin");



                    }
                    else
                    {


                        return RedirectToAction("Index", "Home");
                    }


                }
                return RedirectToAction("Index", "Home");

            }
            else
            {
                TempData["LoginFailed"] = "Yanlış E-mail veya şifre";
                return RedirectToAction("Index");
            }



        }



    }
}

