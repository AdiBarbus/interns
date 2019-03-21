using System.Web.Mvc;
using Interns.Core.Data;
using Interns.Services.IService;

namespace Interns.Presentation.Controllers
{
    public class QaController : Controller
    {
        private readonly IQaService qaService;
        private readonly ISubDomainService subDomainService;
        private readonly IAdvertiseService advertiseService;

        public QaController(IQaService qa, ISubDomainService subDomain, IAdvertiseService advertise)
        {
            qaService = qa;
            subDomainService = subDomain;
            advertiseService = advertise;
        }

        [HttpGet]
        public ActionResult GetAllQas()
        {
            var qas = qaService.GetQas();

            return View(qas);
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult CreateQa()
        {
            ViewBag.SubDomain = subDomainService.GetSubDomains();
            ViewBag.Advertise = advertiseService.GetAdvertises();

            return View();
        }

        [HttpPost]
        public ActionResult CreateQa(Qa qa)
        {
            qaService.InsertQa(qa);

            return RedirectToAction("GetAllQas");
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult EditQa(int id)
        {
            var editQa = qaService.GetQa(id);
            return View(editQa);
        }

        [HttpPost]
        public ActionResult EditQa(Qa qa)
        {
            qaService.UpdateQa(qa);
            return RedirectToAction("GetAllQas");
        }

        [HttpGet]
        public ActionResult DeleteQa(Qa qa)
        {
            qaService.DeleteQa(qa);
            return RedirectToAction("GetAllQas");
        }
    }
}