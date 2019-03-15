using System.Linq;
using System.Web.Mvc;
using InternsDataAccessLayer.Entities;
using InternsServices.IService;
using PagedList;
using static System.String;

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
        //[HttpGet]
        //public ActionResult GetAllSubDomains()
        //{
        //    var getAll = subDomainService.GetAllSubDomains();
        //    return View(getAll);
        //}
        
        public ViewResult GetAllSubDomains(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = IsNullOrEmpty(sortOrder) ? "name_desc" : "";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;
            var getAll = subDomainService.GetAllSubDomains();

            if (!IsNullOrEmpty(searchString))
            {
                getAll = getAll.Where(s => s.Name.Contains(searchString)).ToList();
            }
            switch (sortOrder)
            {
                case "name_desc":
                    getAll = getAll.OrderByDescending(s => s.Name).ToList();
                    break;
                default:  // Name ascending 
                    getAll = getAll.OrderBy(s => s.Id).ToList();
                    break;
            }

            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(getAll.ToPagedList(pageNumber, pageSize));
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