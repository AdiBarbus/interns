using System.Linq;
using System.Web.Mvc;
using InternsDataAccessLayer.Entities;
using InternsMVC.Models;
using InternsServices.IService;
using static System.String;

namespace InternsMVC.Controllers
{
    public class DomainController : Controller
    {
        private readonly IDomainService domainService;
        public int PageSize = 4;
        
        public DomainController(IDomainService domain)
        {
            domainService = domain;
        }
        [HttpGet]
        [AllowAnonymous]
        public ActionResult GetAllDomains(string sortOrder, string currentFilter, string stringSearch,int page = 1)
        {
            var getAll = domainService.GetAllDomains();

            DomainsPagingViewModel model = new DomainsPagingViewModel
                {
                    Domains = getAll.Skip((page - 1) * PageSize).Take(PageSize),
                    PagingInfo = new PagingInfo
                    {
                        CurrentPage = page,
                        ItemsPerPage = PageSize,
                        TotalItems =
                            stringSearch == null ? getAll.Count() : 
                                getAll.Count(s => s.Name.Contains(stringSearch))
                    },
                    sortingOrder = IsNullOrEmpty(sortOrder) ? "name_desc" : "",
                    searchString = stringSearch
                };

            switch (sortOrder)
            {
                case "name_desc":
                    model.Domains = model.Domains.OrderByDescending(s => s.Name).ToList();
                    break;
                default:  // Name ascending 
                    model.Domains = model.Domains.OrderBy(s => s.Id).ToList();
                    break;
            }

            if (!IsNullOrEmpty(stringSearch))
            {
                model.Domains = domainService.GetAllDomains().Where(s => s.Name.Contains(stringSearch));
            }

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
        [Authorize(Roles = "Admin")]
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
        [Authorize(Roles = "Admin")]
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