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
        private readonly UserManager<User> _userManager;
        UsersManager um=new UsersManager(new EfUserRepository());
        private readonly RoleManager<AppRole> _roleManager;
        public RegisterController(UserManager<User> userManager, RoleManager<AppRole> roleManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }
        [AllowAnonymous]
        [HttpGet]
        public IActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                // Kullanıcı zaten giriş yapmışsa, istenilen sayfaya yönlendir.
                return RedirectToAction("Index", "Home");
            }
            ViewBag.TempDataMessage = TempData["Failed"];
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Index(UserSignUpViewModel usr)
        {
            if (User.Identity.IsAuthenticated)
            {
                // Kullanıcı zaten giriş yapmışsa, istenilen sayfaya yönlendir.
                return RedirectToAction("Index", "Home");
            }
            if (ModelState.IsValid)
            {
                User user = new User()
                {

                    Email = usr.Email,
                    PhoneNumber = usr.Phone,
                    NameSurname = usr.Name,
                    UserName=usr.Email

                };
                IdentityResult result=await _userManager.CreateAsync(user,usr.Password);
                if (!await _roleManager.RoleExistsAsync("Member"))
                {
                    var newRole = new AppRole("Member");
                    await _roleManager.CreateAsync(newRole);
                }
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, "Member");
                    return RedirectToAction("Index", "LogIn");


                }
                else
                {

                    TempData["Failed"] = string.Join(", ", result.Errors.Select(e => e.Description));


                    return RedirectToAction("Index");



                }

            }
            return View(usr);
          
        }

    }
}
