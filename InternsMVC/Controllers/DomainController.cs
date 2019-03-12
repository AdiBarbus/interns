using System.Web.Mvc;
using InternsBusiness.Business;
using InternsDataAccessLayer.Entities;

namespace InternsMVC.Controllers
{
    public class DomainController : Controller
    {
        private readonly IDomainBll domainBll;

        public DomainController(IDomainBll domain)
        {
            domainBll = domain;
        }
        [HttpGet]
        public ActionResult GetAllDomains()
        {
            var getAll = domainBll.GetAllDomains();
            return View(getAll);
        }
        [HttpGet]
        [Route("domain/GetSubDomainByDomain/{domainId}")]
        public ActionResult GetSubDomainsByDomain(int domainId)
        {
            var byId = domainBll.GetSubDomainsByDomain(domainId);
            ViewBag.DomainName = domainBll.GetDomainById(domainId).Name;

            return View(byId);
        }
        [HttpGet]
        [Route("domain/GetAdvertisesByDomain/{domainId}")]
        public ActionResult GetAdvertisesByDomain(int domainId)
        {
            var byId = domainBll.GetAdvertisesByDomain(domainId);
            ViewBag.DomainName = domainBll.GetDomainById(domainId).Name;

            return View(byId);
        }


        [HttpGet]
        public ActionResult CreateDomain()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateDomain(Domain domain)
        {
            domainBll.AddDomain(domain);
            return RedirectToAction("GetAllDomains");
        }

        [HttpGet]
        public ActionResult EditDomain(int id)
        {
            var us = domainBll.GetDomainById(id);
            return View(us);
        }

        [HttpPost]
        public ActionResult EditDomain(Domain domain)
        {
            domainBll.EditDomain(domain);
            return RedirectToAction("GetAllDomains");
        }

        [HttpGet]
        public ActionResult DeleteDomain(int id)
        {
            domainBll.DeleteDomain(id);
            return RedirectToAction("GetAllDomains");
        }
    }
}