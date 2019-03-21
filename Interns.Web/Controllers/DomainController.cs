using System.Linq;
using System.Web.Mvc;
using Interns.Core.Data;
using Interns.Services.IService;
using Interns.Web.Models;
using static System.String;

namespace Interns.Web.Controllers
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

            GenericPagingViewModel<Domain> model = new GenericPagingViewModel<Domain>
            {
                    Collection = getAll.Skip((page - 1) * PageSize).Take(PageSize),
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
                    model.Collection = model.Collection.OrderByDescending(s => s.Name).ToList();
                    break;
                default:  // Name ascending 
                    model.Collection = model.Collection.OrderBy(s => s.Id).ToList();
                    break;
            }

            if (!IsNullOrEmpty(stringSearch))
            {
                model.Collection = domainService.GetAllDomains().Where(s => s.Name.Contains(stringSearch));
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
        public ActionResult DeleteDomain(Domain domain)
        {
            domainService.DeleteDomain(domain);
            return RedirectToAction("GetAllDomains");
        }
    }
}