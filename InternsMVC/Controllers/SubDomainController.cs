using System.Web.Mvc;
using InternsBusiness.Business;
using InternsDataAccessLayer.Entities;

namespace InternsMVC.Controllers
{
    public class SubDomainController : Controller
    {
        private readonly ISubDomainBll subDomainBll;
        private readonly IDomainBll domainBll;

        public SubDomainController(ISubDomainBll subDomain, IDomainBll domain)
        {
            subDomainBll = subDomain;
            domainBll = domain;
        }
        [HttpGet]
        public ActionResult GetAllSubDomains()
        {
            var getAll = subDomainBll.GetAllSubDomains();
            return View(getAll);
        }

        [HttpGet]
        [Route("domain/GetAdvertisesBySubDomain/{domainId}")]
        public ActionResult GetAdvertisesBySubDomain(int domainId)
        {
            var byId = subDomainBll.GetAdvertisesBySubDomain(domainId);
            ViewBag.SubDomainName = subDomainBll.GetSubDomainById(domainId).Name;

            return View(byId);
        }

        [HttpGet]
        public ActionResult CreateSubDomain()
        {
            ViewBag.Domain = domainBll.GetAllDomains();
            return View();
        }
        [HttpPost]
        public ActionResult CreateSubDomain(SubDomain domain)
        {
            subDomainBll.AddSubDomain(domain);
            return RedirectToAction("GetAllSubDomains");
        }

        [HttpGet]
        public ActionResult EditSubDomain(int id)
        {
            var us = subDomainBll.GetSubDomainById(id);
            return View(us);
        }

        [HttpPost]
        public ActionResult EditSubDomain(SubDomain subDomain)
        {
            subDomainBll.EditSubDomain(subDomain);
            return RedirectToAction("GetAllSubDomains");
        }

        [HttpGet]
        public ActionResult DeleteSubDomain(int id)
        {
            subDomainBll.DeleteSubDomain(id);
            return RedirectToAction("GetAllSubDomains");
        }
    }

}