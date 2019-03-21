using System;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web.Mvc;
using Interns.Core.Data;
using Interns.Services.IService;

namespace Interns.Web.Controllers
{
    public class RegisterController : Controller
    {
        private readonly IUserService userService;
        private readonly IRoleService roleService;

        public RegisterController(IUserService user, IRoleService role)
        {
            userService = user;
            roleService = role;
        }
        public JsonResult IsUserExists(string UserName)
        {
            var a = userService.GetAllUsers();
            return Json(!a.Any(x => x.UserName == UserName), JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Register()
        {
            ViewBag.Roles = roleService.GetAllRoles().Where(e => e.Type != "Admin");

            return View();
        }

        [HttpPost]
        public ActionResult Register(User user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var crypto = new SimpleCrypto.PBKDF2();

                    var encrypPass = crypto.Compute(user.Password);
                    user.Password = encrypPass;
                    user.PasswordSalt = crypto.Salt;

                    var encrypPassConfirm = crypto.Compute(user.ConfirmPassword);
                    user.ConfirmPassword = encrypPassConfirm;

                    user.CreateDate = DateTime.Now;

                    userService.AddUser(user);


                    return RedirectToAction("Login", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Data is not correct");
                }
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine($"Entity of type \"{eve.Entry.Entity.GetType().Name}\" in state \"{eve.Entry.State}\" has the following validation errors:");
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine($"- Property: \"{ve.PropertyName}\", Error: \"{ve.ErrorMessage}\"");
                    }
                }
                throw;
            }
            return View();
        }
    }
}