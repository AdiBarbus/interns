using System.Web.Mvc;
using Interns.Services.IService;

namespace Interns.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUserService userService;

        public HomeController(IUserService user)
        {
            userService = user;
        }
        public ActionResult Index()
        {
            return View();
        }
    }
}