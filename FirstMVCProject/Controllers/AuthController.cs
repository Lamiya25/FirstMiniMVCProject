using FirstMVCProject.Models;
using FirstMVCProject.Repositories;
using FirstMVCProject.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Security.Claims;

namespace FirstMVCProject.Controllers
{
    [AllowAnonymous] 
    public class AuthController : Controller
    {
        UserRepository userRepository = new UserRepository();
        AppDbContext appDbContext = new AppDbContext();

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegiasterVM model)
        {
            if (ModelState.IsValid)
            {
                User newUser = new User()
                {
                    Name = model.Name,
                    LastName = model.LastName,
                    Email = model.Email,
                    Password = model.Password,
                };
                userRepository.Add(newUser);
                return RedirectToAction("Login");
            }

            return View();
        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginVM model)
        {

            var datavalue = appDbContext.Users.FirstOrDefault(x => x.Email == model.Email && x.Password == model.Password);
            if (datavalue != null)
            {
                var claims = new List<Claim>{
                    new Claim(ClaimTypes.Name,model.Email)
                };
                var useridentity = new ClaimsIdentity(claims, "a");
                ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(useridentity);
                await HttpContext.SignInAsync(claimsPrincipal);

                HttpContext.Session.SetString("username", JsonConvert.SerializeObject(datavalue));
                return RedirectToAction("Index", "Product");
            }

            return View();
        }


    }
}
