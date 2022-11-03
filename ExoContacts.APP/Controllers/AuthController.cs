using ExoContacts.APP.Models;
using ExoContacts.BLL.Services;
using ExoContacts.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ExoContacts.APP.Controllers
{
    public class AuthController : Controller
    {

        private UserService _userService;

        public AuthController(UserService userService)
        {
            _userService = userService;
        }
         public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(AuthRegisterModel authRegister)
        {
            if(!ModelState.IsValid)
            {
                return View(authRegister);
            }

            User? user = _userService.Register(new User()
            {
                Email = authRegister.Email,
                Password = authRegister.Password,
            });

            if(user is null)
            {
                ModelState.AddModelError("Password", "L'email ou le mot de passe est incorrect");
                return View(authRegister);

            }

            HttpContext.Session.SetString("Email", user.Email);

            return RedirectToAction("Index", "Contact");
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(AuthLoginModel authLogin)
        {
            if (!ModelState.IsValid)
            {
                return View(authLogin);
            }
            User? user = _userService.Login(authLogin.Email, authLogin.Password);
            if(user is null)
            {
                ModelState.AddModelError("Password", "L'email ou le mot de passe est incorrect");
                return View(authLogin);
            }

            HttpContext.Session.SetString("Email", user.Email);

            return RedirectToAction("Index","Contact");
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}
