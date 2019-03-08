using System.Web.Mvc;
using InternsBusiness.Business;

namespace InternsMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRoleBll roleBll;

        public HomeController(IRoleBll bll)
        {
            roleBll = bll;
        }
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult GetAll()
        {
            var getAll = roleBll.GetAllRoles();
            return View(getAll);
        }
    }
}