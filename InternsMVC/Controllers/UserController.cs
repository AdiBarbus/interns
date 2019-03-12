using System.Collections.Generic;
using System.Web.Mvc;
using InternsBusiness.Business;
using InternsDataAccessLayer.Entities;

namespace InternsMVC.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserBll userBll;
        private readonly IRoleBll roleBll;

        public UserController(IUserBll user, IRoleBll role)
        {
            userBll = user;
            roleBll = role;
        }
        
        [HttpGet]
        public ActionResult GetAllUsers()
        {
            var getAll = userBll.GetAllUsers();
            return View(getAll);
        }

        [HttpGet]
        public ActionResult CreateUser()
        {
            List<SelectListItem> items = new List<SelectListItem>();
            foreach (var role in roleBll.GetAllRoles())
            {
                items.Add(new SelectListItem { Text = role.Type, Value = role.Type });
            }

            ViewBag.RoleType = items;
            return View();
        }

        [HttpPost]
        public ActionResult CreateUser(User user)
        {
            user.Role.Type = "Student";
            userBll.AddUser(user);
            
            return RedirectToAction("GetAllUsers");
        }

        //[HttpGet]
        //public ActionResult SelectRole()
        //{
        //    List<SelectListItem> items = new List<SelectListItem>();
        //    foreach (var role in roleBll.GetAllRoles())
        //    {
        //        items.Add(new SelectListItem { Text = role.Type, Value = role.Type });
        //    }

        //    ViewBag.RoleType = items;
        //    return View();
        //}

        [HttpGet]
        public ActionResult EditUser(int id)
        {
            var us = userBll.GetUserById(id);
            return View(us);
        }

        [HttpPost]
        public ActionResult EditUser(User user)
        {
            userBll.EditUser(user);
            return RedirectToAction("GetAllUsers");
        }

        [HttpGet]
        public ActionResult DeleteUser(int id)
        {
            userBll.DeleteUser(id);
            return RedirectToAction("GetAllUsers");
        }
    }
}