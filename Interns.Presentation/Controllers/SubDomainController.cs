using System.Linq;
using System.Web.Mvc;
using Interns.Core.Data;
using Interns.Services.Helpers;
using Interns.Services.IService;
using Interns.Services.Models.SelectFK;
using static System.String;

namespace Interns.Presentation.Controllers
{
    public class SubDomainController : Controller
    {
        private readonly ISubDomainService subDomainService;
        private readonly IDomainService domainService;
        public int PageSize = 10;
        
        public SubDomainController(ISubDomainService subDomain, IDomainService domain)
        {
            subDomainService = subDomain;
            domainService = domain;
        }

        public ActionResult GetAllSubDomains(string stringSearch, string sortOrder, string currentFilter, int page = 1)
        {
            var getSubDomains = subDomainService.GetSubDomains();

            SearchingAndPagingViewModel<SubDomain> model = new SearchingAndPagingViewModel<SubDomain>
            {
                Collection = getSubDomains.OrderBy(p => p.Name).Skip((page - 1) * PageSize).Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems =
                        stringSearch == null ? getSubDomains.Count() :
                            getSubDomains.Count(s => s.Name.Contains(stringSearch))
                },
                SortingOrder = IsNullOrEmpty(sortOrder) ? "name_desc" : "",
                SearchString = stringSearch
            };

            switch (sortOrder)
            {
                case "name_desc":
                    model.Collection = model.Collection.OrderByDescending(s => s.DomainId);
                    break;
                default:  // Name ascending 
                    model.Collection = model.Collection.OrderBy(s => s.DomainId);
                    break;
            }

            if (!IsNullOrEmpty(stringSearch))
            {
                model.Collection = getSubDomains.Where(s => s.Name.Contains(stringSearch));
            }
            return View(model);
        }

        [HttpGet]
        [Route("domain/GetAdvertisesBySubDomain/{domainId}")]
        public ActionResult GetAdvertisesBySubDomain(int domainId)
        {
            var advertisesBySubDomain = subDomainService.GetAdvertisesBySubDomain(domainId);
            //ViewBag.SubDomainName = subDomainService.GetSubDomain(domainId).Name;

            return View(advertisesBySubDomain);
        }

        [HttpGet]
        public ActionResult SelectDomain()
        {
            SelectDomainViewModel model = new SelectDomainViewModel();
            model.Domains = domainService.GetDomains();

            return View(model);
        }

        [HttpPost]
        public ActionResult SelectRole(SelectDomainViewModel model)
        {
            SubDomain subDomain = new SubDomain();
            subDomain.DomainId = model.SelectedDomainId;

            return RedirectToAction("CreateSubDomain", new
            {
                subDomain.DomainId
            });
        }


        [HttpGet]
        public ActionResult CreateSubDomain()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateSubDomain(SubDomain subDomain, int domainId)
        {
            subDomain.DomainId = domainId;
            subDomainService.InsertSubDomain(subDomain);

            return RedirectToAction("GetAllSubDomains");
        }

        [HttpGet]
        public ActionResult EditSubDomain(int id)
        {
            var subDomain = subDomainService.GetSubDomain(id);
            return View(subDomain);
        }

        [HttpPost]
        public ActionResult EditSubDomain(SubDomain subDomain)
        {
            if (ModelState.IsValid)
            {
                subDomainService.UpdateSubDomain(subDomain);
                return RedirectToAction("GetAllSubDomains");
            }
            else
            {
                return View(subDomain);
            }
        }

        [HttpGet]
        public ActionResult DeleteSubDomain(SubDomain subDomain)
        {
            subDomainService.DeleteSubDomain(subDomain);
            return RedirectToAction("GetAllSubDomains");
        }
    }
}