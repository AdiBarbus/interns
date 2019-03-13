using System.Linq;
using System.Web.Mvc;
using InternsBusiness.Business;
using InternsDataAccessLayer.Entities;

namespace InternsMVC.Controllers
{
    public class QAController : Controller
    {
        private readonly IQABll qaBll;
        private readonly ISubDomainBll subDomainBll;
        private readonly IAdvertiseBll advertiseBll;

        public QAController(IQABll qa, ISubDomainBll subDomain, IAdvertiseBll advertise)
        {
            qaBll = qa;
            subDomainBll = subDomain;
            advertiseBll = advertise;
        }

        [HttpGet]
        public ActionResult GetAllQAs()
        {
            var getAll = qaBll.GetAllQAs();
            return View(getAll);
        }

        [HttpGet]
        public ActionResult CreateQA()
        {
            ViewBag.SubDomain = subDomainBll.GetAllSubDomains();
            ViewBag.Advertise = advertiseBll.GetAllAdvertises();

            return View();
        }

        [HttpPost]
        public ActionResult CreateQA(QA qa)
        {
            qaBll.AddQA(qa);

            return RedirectToAction("GetAllQAs");
        }

        [HttpGet]
        public ActionResult EditQA(int id)
        {
            var us = qaBll.GetQAById(id);
            return View(us);
        }

        [HttpPost]
        public ActionResult EditQA(QA qa)
        {
            qaBll.EditQA(qa);
            return RedirectToAction("GetAllQAs");
        }

        [HttpGet]
        public ActionResult DeleteQA(int id)
        {
            qaBll.DeleteQA(id);
            return RedirectToAction("GetAllQAs");
        }
    }
}
