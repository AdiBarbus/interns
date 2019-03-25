using System.Linq;
using System.Web.Mvc;
using System.Web.Security;
using Interns.Services.DTO;
using Interns.Services.IService;
using Interns.Services.Models;
using SimpleCrypto;

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
                return RedirectToAction("GetAllAdvertises", "Advertise");
            }

            ModelState.AddModelError("", "Login details are wrong.");

            return View(loginModel);
        }

        [Authorize]
        public ActionResult ChangePassword()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult ChangePassword(ChangePasswordModel model)
        {
            if (ModelState.IsValid)
            {
                var crypto = new PBKDF2();
                var user = userService.GetUsers().FirstOrDefault(u => u.UserName == User.Identity.Name);

                if (user.Password == crypto.Compute(model.OldPassword, user.PasswordSalt))
                {
                    user.Password = crypto.Compute(model.NewPassword);
                    user.ConfirmPassword = crypto.Compute(model.ConfirmPassword);
                    userService.UpdateUser(user);
                    
                    return RedirectToAction("ChangePasswordSuccess");
                }

                ModelState.AddModelError("", "The current password is incorrect or the new password is invalid.");
            }

            return View(model);
        }
        public ActionResult ChangePasswordSuccess()
        {
            return View();
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("GetAllAdvertises", "Advertise");
        }

        private bool IsValid(string userName, string password)
        {
            var crypto = new PBKDF2();
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