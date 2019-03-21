using System;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web.Mvc;
using Interns.Core.Data;
using Interns.Services.IService;
using static System.String;

namespace Interns.Web.Controllers
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
        [Authorize(Roles = "Admin")]
        public ActionResult GetAllUsers(string sortOrder, string searchString)
        {
            ViewBag.UserNameSortParm = IsNullOrEmpty(sortOrder) ? "name_desc" : "";

            var getAll = userService.GetAllUsers();

            if (!IsNullOrEmpty(searchString))
            {
                getAll = getAll.Where(s => s.UserName.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    getAll = getAll.OrderByDescending(s => s.UserName);
                    break;
                default:
                    getAll = getAll.OrderBy(s => s.UserName);
                    break;
            }

            return View(getAll.ToList());
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult CreateUser()
        {
            ViewBag.Roles = roleService.GetAllRoles();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateUser(User user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    user.CreateDate = DateTime.Now;
                    userService.AddUser(user);
                    return RedirectToAction("GetAllUsers");
                }
            }
            catch (RetryLimitExceededException e)
            {
                throw e;
            }
            return View(user);
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult EditUser(int id)
        {
            var us = userService.GetUserById(id);
            return View(us);
        }

        [HttpPost]
        public ActionResult EditUser(User user)
        {
            if (ModelState.IsValid)
            {
                userService.EditUser(user);
                return RedirectToAction("GetAllUsers");
            }
            else
            {
                return View(user);
            }
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteUser(User user)
        {
            userService.DeleteUser(user);
            return RedirectToAction("GetAllUsers");
        }
    }
}