using System.Web.Mvc;
using InternsServices.Service;
using InternsDataAccessLayer.Entities;

namespace InternsMVC.Controllers
{
    public class SubDomainController : Controller
    {
        private readonly ISubDomainService subDomainService;
        private readonly IDomainService domainService;

        public SubDomainController(ISubDomainService subDomain, IDomainService domain)
        {
            subDomainService = subDomain;
            domainService = domain;
        }
        [HttpGet]
        public ActionResult GetAllSubDomains()
        {
            var getAll = subDomainService.GetAllSubDomains();
            return View(getAll);
        }

        [HttpGet]
        [Route("domain/GetAdvertisesBySubDomain/{domainId}")]
        public ActionResult GetAdvertisesBySubDomain(int domainId)
        {
            var byId = subDomainService.GetAdvertisesBySubDomain(domainId);
            ViewBag.SubDomainName = subDomainService.GetSubDomainById(domainId).Name;

            return View(byId);
        }

        [HttpGet]
        public ActionResult CreateSubDomain()
        {
            ViewBag.Domain = domainService.GetAllDomains();
            return View();
        }
        [HttpPost]
        public ActionResult CreateSubDomain(SubDomain domain)
        {
            subDomainService.AddSubDomain(domain);
            return RedirectToAction("GetAllSubDomains");
        }

        [HttpGet]
        public ActionResult EditSubDomain(int id)
        {
            var us = subDomainService.GetSubDomainById(id);
            return View(us);
        }

        [HttpPost]
        public ActionResult EditSubDomain(SubDomain subDomain)
        {
            if (ModelState.IsValid)
            {
                subDomainService.EditSubDomain(subDomain);
                return RedirectToAction("GetAllSubDomains");
                }
            else
            {
                return View(subDomain);
            }
        }

        [HttpGet]
        public ActionResult DeleteSubDomain(int id)
        {
            subDomainService.DeleteSubDomain(id);
            return RedirectToAction("GetAllSubDomains");
        }
    }

}