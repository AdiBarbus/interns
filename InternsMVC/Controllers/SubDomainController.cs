using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using InternsBusiness.Business;
using InternsDataAccessLayer.Entities;

namespace InternsMVC.Controllers
{
    public class SubDomainController : Controller
    {
        private readonly ISubDomainBll subDomainBll;

        public SubDomainController(ISubDomainBll domain)
        {
            subDomainBll = domain;
        }
        [HttpGet]
        public ActionResult GetAllSubDomains()
        {
            var getAll = subDomainBll.GetAllSubDomains();
            return View(getAll);
        }

        [HttpGet]
        public ActionResult CreateSubDomain()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateSubDomain(SubDomain domain)
        {
            subDomainBll.AddSubDomain(domain);
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