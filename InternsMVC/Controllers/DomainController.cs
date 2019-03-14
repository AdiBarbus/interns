using System.Linq;
using System.Web.Mvc;
using InternsServices.Service;
using InternsDataAccessLayer.Entities;
using InternsMVC.Models;

namespace InternsMVC.Controllers
{
    public class DomainController : Controller
    {
        private readonly IDomainService domainService;
        public int PageSize = 7;
        
        public DomainController(IDomainService domain)
        {
            domainService = domain;
        }
        [HttpGet]
        //[Route("domain/GetAllDomains/{page}")]
        public ActionResult GetAllDomains(int page = 1)
        {
            var getAll = domainService.GetAllDomains();

            DomainsPagingViewModel model = new DomainsPagingViewModel
            {
                Domains = getAll.Skip((page - 1) * PageSize).Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = getAll.Count()
                }
            };
            return View(model);
        }
        [HttpGet]
        [Route("domain/GetSubDomainByDomain/{domainId}")]
        public ActionResult GetSubDomainsByDomain(int domainId)
        {
            var byId = domainService.GetSubDomainsByDomain(domainId);
            ViewBag.DomainName = domainService.GetDomainById(domainId).Name;

            return View(byId);
        }
        [HttpGet]
        [Route("domain/GetAdvertisesByDomain/{domainId}")]
        public ActionResult GetAdvertisesByDomain(int domainId)
        {
            var byId = domainService.GetAdvertisesByDomain(domainId);
            ViewBag.DomainName = domainService.GetDomainById(domainId).Name;

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
            domainService.AddDomain(domain);
            return RedirectToAction("GetAllDomains");
        }

        [HttpGet]
        public ActionResult EditDomain(int id)
        {
            var us = domainService.GetDomainById(id);
            return View(us);
        }

        [HttpPost]
        public ActionResult EditDomain(Domain domain)
        {
            domainService.EditDomain(domain);
            return RedirectToAction("GetAllDomains");
        }

        [HttpGet]
        public ActionResult DeleteDomain(int id)
        {
            domainService.DeleteDomain(id);
            return RedirectToAction("GetAllDomains");
        }
    }
}