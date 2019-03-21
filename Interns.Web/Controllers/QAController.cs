using System.Web.Mvc;
using Interns.Core.Data;
using Interns.Services.IService;

namespace Interns.Web.Controllers
{
    public class QaController : Controller
    {
        private readonly IQaService iqaService;
        private readonly ISubDomainService subDomainService;
        private readonly IAdvertiseService advertiseService;

        public QaController(IQaService qa, ISubDomainService subDomain, IAdvertiseService advertise)
        {
            iqaService = qa;
            subDomainService = subDomain;
            advertiseService = advertise;
        }

        [HttpGet]
        public ActionResult GetAllQas()
        {
            var getAll = iqaService.GetAllQas();
            return View(getAll);
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult CreateQa()
        {
            ViewBag.SubDomain = subDomainService.GetAllSubDomains();
            ViewBag.Advertise = advertiseService.GetAllAdvertises();

            return View();
        }

        [HttpPost]
        public ActionResult CreateQa(Qa qa)
        {
            iqaService.AddQa(qa);

            return RedirectToAction("GetAllQas");
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult EditQa(int id)
        {
            var us = iqaService.GetQAById(id);
            return View(us);
        }

        [HttpPost]
        public ActionResult EditQa(Qa qa)
        {
            iqaService.EditQa(qa);
            return RedirectToAction("GetAllQas");
        }

        [HttpGet]
        public ActionResult DeleteQa(Qa qa)
        {
            iqaService.DeleteQa(qa);
            return RedirectToAction("GetAllQas");
        }
    }
}
