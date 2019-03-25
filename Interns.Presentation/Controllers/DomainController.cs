using System.Linq;
using System.Web.Mvc;
using Interns.Core.Data;
using Interns.Services.DTO;
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
        public ActionResult GetAllDomains(string stringSearch, string sortOrder, string currentFilter, int page = 1)
        {
            var getDomains = domainService.GetDomains();

            SearchingAndPagingViewModel<Domain> model = new SearchingAndPagingViewModel<Domain>
            {
                Collection = getDomains.OrderBy(p=>p.Name).Skip((page - 1) * PageSize).Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems =
                            stringSearch == null ? getDomains.Count() :
                                getDomains.Count(s => s.Name.Contains(stringSearch))
                },
                SortingOrder = IsNullOrEmpty(sortOrder) ? "name_desc" : "",
                SearchString = stringSearch
            };
            
            switch (sortOrder)
            {
                case "name_desc":
                    model.Collection = model.Collection.OrderByDescending(s => s.Name);
                    break;
                default:  // Name ascending 
                    model.Collection = model.Collection.OrderBy(s => s.Name);
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
            var subDomainsByDomain = domainService.GetSubDomainsByDomain(domainId);

            return View(subDomainsByDomain);
        }

        [HttpGet]
        [Route("domain/GetAdvertisesByDomain/{domainId}")]
        public ActionResult GetAdvertisesByDomain(int domainId)
        {
            var advertisesByDomain = domainService.GetAdvertisesByDomain(domainId);

            return View(advertisesByDomain);
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
            var domain = domainService.GetDomain(id);
            return View(domain);
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