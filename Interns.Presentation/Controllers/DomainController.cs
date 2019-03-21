using System.Linq;
using System.Web.Mvc;
using Interns.Core.Data;
using Interns.Presentation.Models;
using Interns.Services.IService;
using static System.String;

namespace Interns.Presentation.Controllers
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
        public ActionResult GetAllDomains(string sortOrder, string currentFilter, string stringSearch, int page = 1)
        {
            var getAll = domainService.GetDomains();

            GenericPagingViewModel<Domain> model = new GenericPagingViewModel<Domain>
            {
                Collection = getAll.OrderBy(p=>p.Id).Skip((page - 1) * PageSize).Take(PageSize),
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
                    model.Collection = model.Collection.OrderByDescending(s => s.Name);
                    break;
                default:  // Name ascending 
                    model.Collection = model.Collection.OrderBy(s => s.Id);
                    break;
            }

            if (!IsNullOrEmpty(stringSearch))
            {
                model.Collection = domainService.GetDomains().Where(s => s.Name.Contains(stringSearch));
            }

            return View(model);
        }

        [HttpGet]
        [Route("domain/GetSubDomainByDomain/{domainId}")]
        public ActionResult GetSubDomainsByDomain(int domainId)
        {
            var byId = domainService.GetSubDomainsByDomain(domainId);
            ViewBag.DomainName = domainService.GetDomain(domainId).Name;

            return View(byId);
        }

        [HttpGet]
        [Route("domain/GetAdvertisesByDomain/{domainId}")]
        public ActionResult GetAdvertisesByDomain(int domainId)
        {
            var byId = domainService.GetAdvertisesByDomain(domainId);
            ViewBag.DomainName = domainService.GetDomain(domainId).Name;

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
            domainService.InsertDomain(domain);
            return RedirectToAction("GetAllDomains");
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult EditDomain(int id)
        {
            var us = domainService.GetDomain(id);
            return View(us);
        }

        [HttpPost]
        public ActionResult EditDomain(Domain domain)
        {
            domainService.UpdateDomain(domain);
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