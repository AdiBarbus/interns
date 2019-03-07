using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using InternsBusiness.Business;

namespace InternsMVC.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserBll userBll;

        public UserController(IUserBll user)
        {
            userBll = user;
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
    }
}