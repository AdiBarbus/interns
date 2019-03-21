using System.Linq;
using System.Web.Mvc;
using System.Web.Security;
using Interns.Core.Data;
using Interns.Presentation.Models;
using Interns.Services.IService;

namespace Interns.Presentation.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUserService userService;
        public int PageSize = 3;

        public LoginController(IUserService user)
        {
            userService = user;
        }
        [HttpGet]
        public ActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LogIn(LoginInputModel loginModel)
        {
            if (IsValid(loginModel.UserName, loginModel.Password))
            {
                FormsAuthentication.SetAuthCookie(loginModel.UserName, false);
                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError("", "Login details are wrong.");

            return View(loginModel);
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

        private bool IsValid(string userName, string password)
        {
            var crypto = new SimpleCrypto.PBKDF2();
            bool IsValid = false;

            var user = userService.GetUsers().FirstOrDefault(u => u.UserName == userName);
            if (user != null)
            {
                if (user.Password == crypto.Compute(password, user.PasswordSalt))
                {
                    IsValid = true;
                }
            }
            return IsValid;
        }
    }
}