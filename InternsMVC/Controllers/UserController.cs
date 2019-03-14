using System.Web.Mvc;
using InternsServices.Service;
using InternsDataAccessLayer.Entities;

namespace InternsMVC.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService userService;
        private readonly IRoleService roleService;

        public UserController(IUserService user, IRoleService role)
        {
            userService = user;
            roleService = role;
        }
        
        [HttpGet]
        public ActionResult GetAllUsers()
        {
            var getAll = userService.GetAllUsers();
            return View(getAll);
        }
        
        [HttpGet]
        public ActionResult CreateUser()
        {
            ViewBag.Roles = roleService.GetAllRoles();
            return View();
        }

        [HttpPost]
        public ActionResult CreateUser(User user)
        {
            if (ModelState.IsValid)
            {
                userService.AddUser(user);
            }

            return RedirectToAction("GetAllUsers");
        }

        [HttpGet]
        public ActionResult EditUser(int id)
        {
            var us = userService.GetUserById(id);
            return View(us);
        }

        [HttpPost]
        public ActionResult EditUser(User user)
        {
            userService.EditUser(user);
            return RedirectToAction("GetAllUsers");
        }

        [HttpGet]
        public ActionResult DeleteUser(int id)
        {
            userService.DeleteUser(id);
            return RedirectToAction("GetAllUsers");
        }
    }
}