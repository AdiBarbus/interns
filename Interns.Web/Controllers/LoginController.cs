using System.Linq;
using System.Web.Mvc;
using System.Web.Security;
using Interns.Core.Data;
using Interns.Services.IService;

namespace Interns.Web.Controllers
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
        public ActionResult LogIn(User user)
        {
            if (IsValid(user.UserName, user.Password))
            {
                FormsAuthentication.SetAuthCookie(user.UserName, false);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("", "Login details are wrong.");
            }
            return View(user);
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

            var user = userService.GetAllUsers().FirstOrDefault(u => u.UserName == userName);
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