using System;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;
using InternsDataAccessLayer.Entities;
using InternsServices.IService;

namespace InternsMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUserService userService;
        private readonly IRoleService roleService;

        public HomeController(IUserService user, IRoleService role)
        {
            userService = user;
            roleService = role;
        }
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LogIn(User userr)
        {

            if (ModelState.IsValid)
            {
                FormsAuthentication.SetAuthCookie(userr.UserName, true);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("", "Login details are wrong.");
            }
            return View(userr);
        }

        [HttpGet]
        public ActionResult Register()
        {
            ViewBag.Roles = roleService.GetAllRoles();

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
                        user.ConfirmPassword = crypto.Salt;
                        user.CreateDate = DateTime.Now;

                        userService.AddUser(user);
                        
                    
                        return RedirectToAction("Index", "Home");
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
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
            }
            return View();
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
                    if (user.Password == crypto.Compute(password, user.ConfirmPassword))
                    {
                        IsValid = true;
                    }
                }
            return IsValid;
        }
    }
}