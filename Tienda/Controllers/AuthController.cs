using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;

namespace Tienda.Controllers
{
    public class AuthController : Controller
    {
        // GET: Auth
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SingIn(FormCollection formCollection)
        {
            var userStore = new UserStore<IdentityUser>();
            var userManager = new UserManager<IdentityUser>(userStore);
            var user = userManager.Find(formCollection["user"], formCollection["password"]);

            if (user != null)
            {
                var authenticationManager = System.Web.HttpContext.Current.GetOwinContext().Authentication;
                var userIdentity = userManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);

                authenticationManager.SignIn(new AuthenticationProperties() { IsPersistent = false }, userIdentity);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                string error = "Invalid username or password."; //TODO
            }
            return RedirectToAction("Login");
        }

        public ActionResult SignOut()
        {
            var authenticationManager = System.Web.HttpContext.Current.GetOwinContext().Authentication;
            authenticationManager.SignOut();
            return RedirectToAction("Login");
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NewRegister(FormCollection formCollection)
        {

            if (formCollection["confirm-password"] == formCollection["password"])
            {
                var userStore = new UserStore<IdentityUser>();
                var manager = new UserManager<IdentityUser>(userStore);
                var user = new IdentityUser() { UserName = formCollection["user"] };

                IdentityResult result = manager.Create(user, formCollection["password"]);
                
                if (result.Succeeded)
                {
                    var authenticationManager = System.Web.HttpContext.Current.GetOwinContext().Authentication;
                    var userIdentity = manager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
                    authenticationManager.SignIn(new AuthenticationProperties() { }, userIdentity);
                    return View("Login");
                }
                else
                {
                    string error = result.Errors.FirstOrDefault(); //TODO
                }
            }
            return View("Register");
        }
    }
}