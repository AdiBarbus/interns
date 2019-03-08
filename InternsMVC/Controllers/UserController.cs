using System.Collections.Generic;
using System.Web.Mvc;
using InternsBusiness.Business;

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

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            var getAll = userBll.GetAllUsers();
            return View(getAll);
        }

        [HttpGet]
        public ActionResult Create()
        {
            List<SelectListItem> items = new List<SelectListItem>();
            foreach (var role in roleBll.GetAllRoles())
            {
                items.Add(new SelectListItem { Text = role.Type, Value = role.Type });
            }

            return View();
        }

        [HttpGet]
        public ActionResult SelectRole()
        {
            List<SelectListItem> items = new List<SelectListItem>();
            foreach (var role in roleBll.GetAllRoles())
            {
                items.Add(new SelectListItem { Text = role.Type, Value = role.Type });
            }

            ViewBag.RoleType = items;
            return View();
        }

        public ActionResult Edit(int id)
        {
            var us = userBll.GetUserById(id);
            return View(us);
        }
        
    }
}