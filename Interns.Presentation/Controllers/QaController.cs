using System.Web.Mvc;
using Interns.Core.Data;
using Interns.Services.IService;
using Interns.Services.Models.SelectFK;

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
        public ActionResult SelectQasForeignKeys()
        {
            SelectQasFKs setForeignKeys = new SelectQasFKs();
            
            setForeignKeys.Advertises = advertiseService.GetAdvertises();
            setForeignKeys.SubDomains = subDomainService.GetSubDomains();

            return View(setForeignKeys);
        }

        [HttpPost]
        public ActionResult SelectQasForeignKeys(SelectQasFKs model)
        {
            Qa qa = new Qa();

            qa.AdvertiseId = model.SelectedAdvertiseId;
            qa.SubDomainId = model.SelectedSubDomainId;

            return RedirectToAction("CreateQa", new
            {
                qa.AdvertiseId,
                qa.SubDomainId
            });
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult CreateQa()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateQa(Qa qa, int advertiseId, int subDomainId)
        {
            qa.AdvertiseId = advertiseId;
            qa.SubDomainId = subDomainId;
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