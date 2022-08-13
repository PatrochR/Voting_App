using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Models.Context;
using Voting_App.Models;
using Voting_App.Repository;
using Voting_App.ViewModel;

namespace Voting_App.Controllers
{


    public class AccountController : Controller
    {
        private readonly IUserRegister _userRegister;
        public AccountController(IUserRegister userRegister)
        {
            _userRegister = userRegister; 
        }
        
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        
        public IActionResult Register(RegisterViewModel model) 
        {
            if(!ModelState.IsValid)
            {
                return View(model);
            }
            if(_userRegister.IsExistUserByUserName(model.UserName))
            {
                ModelState.AddModelError("UserName" , "UserName already exists");
                return View(model);
            }
            var user = new User()
            {
                UserName = model.UserName,
                UserNameConfirmed = model.UserName.ToUpper(),
                Password = model.Password
            };
            var result = _userRegister.AddUser(user);
            if(result)
            {
                if (Url.IsLocalUrl(ViewBag.returnUrl))
                    return Redirect(ViewBag.returnUrl);
                else
                    return RedirectToAction("Index", "Home");
            }
            return View(model); 
        } 

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model )
        {
            if(!ModelState.IsValid)
            {
                return View(model);
            }
            var user = _userRegister.GetUserForLogin(model.UserName , model.Password);

            if(user == null)
            {
                ModelState.AddModelError("" , "UserName or Password isn't true");
                return View(model);
            }

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier , user.UserId.ToString()),
                new Claim(ClaimTypes.Name , user.UserName)
            };

            var identity = new ClaimsIdentity(claims , CookieAuthenticationDefaults.AuthenticationScheme);

            var principal = new ClaimsPrincipal(identity);

            var properties = new AuthenticationProperties()
            {
                IsPersistent = model.RememberMe
            };

            await HttpContext.SignInAsync(principal , properties);

            return Redirect("/");
        }


        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction(nameof(Login));
        }
    }
}