using AtiFlight.BusinessLayer.Concrete;
using AtiFlight.EntityFramework;
using AtiFlight.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AtiFlight.Controllers
{
    public class RegisterController:Controller
    {
        UsersManager um=new UsersManager(new EfUserRepository());
        [AllowAnonymous]
        public IActionResult Index()
        {

            ViewBag.TempDataMessage = TempData["Failed"];
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public IActionResult Index(User usr)
        {
            // Set success message
            var Users = um.GetAll();
            var Emails=Users.Select(p => p.Email).ToList();
            foreach (var mail in Emails)
            {
                if (usr.Email == mail)
                {

                    TempData["Failed"] = "Bu hesap zaten mevcut";
                   

                    return RedirectToAction("Index");

                }





            }
           

            um.TAdd(usr);
           TempData["RegisterSucceed"] = "Kayıt Başarılı Lütfen Giriş Yapın";
            return RedirectToAction("Index","LogIn");
           
          
        }

    }
}
