using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using Site.Models;

namespace Site.Controllers
{
    [AllowAnonymous]
    public class AuthController : BaseController
    {
        [HttpGet]
        public ActionResult LogIn(string returnUrl)
        {
            var model = new LogInModel
            {
                ReturnUrl = returnUrl
            };
            return View(model);
        }
        [HttpPost]
        public ActionResult LogIn(LogInModel model)
        {
            if (!ModelState.IsValid)
                return View();

            if (model.Email == "pp@pp.com" && model.Password == "123")
            {
                var claims = new[]
                {
                    new Claim(ClaimTypes.Name, "pp@pp.com"),
                    new Claim(ClaimTypes.Email, "pp@pp.com"),
                    new Claim(ClaimTypes.Country, "Argentina"),
                };
                var identity = new ClaimsIdentity(claims, "ApplicationCookie");
                IOwinContext ctx = Request.GetOwinContext();
                IAuthenticationManager authManager = ctx.Authentication;
                authManager.SignIn(identity);
                return Redirect(GetRedirectUrl(model.ReturnUrl));
            }
            ModelState.AddModelError("", "El correo electrónico o la contraseña no son válidos.");
            return View();
        }
        public ActionResult LogOut()
        {
            var ctx = Request.GetOwinContext();
            var authManager = ctx.Authentication;

            authManager.SignOut("ApplicationCookie");
            return RedirectToAction("Index", "Home");
        }

    }
}